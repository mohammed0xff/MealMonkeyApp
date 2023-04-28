using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MealMonkey.Domain.Entities.UserEntities;
using MealMonkey.Application.Settings;
using MealMonkey.Application.Common;
using MealMonkey.Domain.entities.User;
using System.Security.Cryptography;
using MealMonkey.Application.Services.Mailing;

namespace MealMonkey.Application.Services.Authantication
{
    public class AuthanticationService : IAuthanticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly JWT _jwt;
        private readonly IMailingService _mailingService;

        public AuthanticationService(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IOptions<JWT> jwt, IMailingService mailingService)
        {
            _userManager = userManager;
            _context = context;
            _jwt = jwt.Value;
            _mailingService = mailingService;
        }

        public async Task<AuthanticationResponseDto> RegisterAsync(RegisterDto model)
        {
            AuthanticationResponseDto response = new();

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                response.Message = "Email is already registered!";
                return response;
            }

            ApplicationUser user = new()
            {
                Email = model.Email,
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                response.Message = errors;

                return response;
            }

            // create Authantication Tecket Include:- { jwt, jwtExpireDateTime, refrehToken, refrehTokenExpireDateTime }
            response = await CreateAuthTecket(user);

            return response;
        }


        public async Task<AuthanticationResponseDto> LoginAsync(LoginDto model)
        {
            AuthanticationResponseDto response = new();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                response.Message = "Email or Password is incorrect!";
                return response;
            }

            // create Authantication Tecket Include:- { jwt, jwtExpireDateTime, refrehToken, refrehTokenExpireDateTime }
            response = await CreateAuthTecket(user);

            return response;
        }


        public async Task<ServiceResult> ChangePasswordAsync(ChangePasswordDto model, string currentUserId)
        {
            var currentUser = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == currentUserId);
            var result = await _userManager.ChangePasswordAsync(currentUser, model.CurrentPassword, model.NewPassword);
            ServiceResult serviceResult = new();

            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var e in result.Errors)
                    errors += $"{e.Description},";

                serviceResult.Msg = errors;

                return serviceResult;
            }

            serviceResult.IsSucceded = true;
            serviceResult.Msg = "Your Password Changed Successfully.";

            //rovoke All Tokens
            RevokeAllTokens(currentUserId);

            return serviceResult;
        }



        // Refresh Token
        public async Task<AuthanticationResponseDto> RefreshTokenAsync(RefreshTokenDto model)
        {
            var response = new AuthanticationResponseDto();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == model.RefreshToken));
            if (user is null)
            {
                response.Message = "Invalid token";
                return response;
            }

            var refreshTokenInDb = _context.RefreshTokens.Single(t => t.Token == model.RefreshToken);
            if (!refreshTokenInDb.IsActive)
            {
                response.Message = "Inactive token";
                return response;
            }

            refreshTokenInDb.RevokedOn = DateTime.UtcNow;

            // create Authantication Tecket Include:- { jwt, jwtExpireDateTime, refrehToken, refrehTokenExpireDateTime }
            response = await CreateAuthTecket(user);

            return response;
        }

        public async Task<bool> RevokeTokenAsync(RefreshTokenDto model, string currentUserId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == model.RefreshToken));

            if (user == null)
                return false;

            var refreshTokenInDb = user.RefreshTokens.Single(t => t.Token == model.RefreshToken);

            if (!refreshTokenInDb.IsActive || refreshTokenInDb.UserId != currentUserId)
                return false;

            // on this step frontEnd should remove saved tokens (jwt, refreshToken)
            refreshTokenInDb.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        public bool RevokeAllTokens(string currentUserId)
        {
            // Revoke all RefreshTokens related with this user
            try
            {
                var userRefreshTokens = _context.RefreshTokens.Where(r => r.UserId == currentUserId && r.RevokedOn == null).ToList();
                foreach (var token in userRefreshTokens)
                {
                    token.RevokedOn = DateTime.UtcNow;
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        // Private Methods
        private async Task<AuthanticationResponseDto> CreateAuthTecket(ApplicationUser user)
        {
            var response = new AuthanticationResponseDto();

            // JWT
            var jwtSecurityToken = await GenerateJwtToken(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.ExpiresOn = jwtSecurityToken.ValidTo;

            // Refresh Token
            var refreshToken = GenerateRefreshToken();
            response.RefreshToken = refreshToken.Token;
            response.RefreshTokenExpiration = refreshToken.ExpiresOn;

            // add refresh Token To Database
            refreshToken.UserId = user.Id;
            _context.RefreshTokens.Add(refreshToken);
            _context.SaveChanges();

            response.Message = string.Empty;
            response.IsAuthanticated = true;

            return response;
        }

        private async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("userId", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);

            var token = Convert.ToBase64String(randomNumber);

            return new RefreshToken()
            {
                Token = token,
                ExpiresOn = DateTime.UtcNow.AddMinutes(_jwt.RefreshTokenDurationInDays), // just to test Change [AddMinutes] To [AddDayes]
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}