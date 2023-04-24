using MealMonkey.Application.Common;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MealMonkey.Application.Services.Token
{
    internal class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public TokenService(
            UserManager<User> userManager, 
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<TokenResponse?> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Add claims 
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    // key , algorithm
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Generate a refresh token
            var refreshToken = Guid.NewGuid()
                .ToString("N"); // N fromat : the string without any separating dashes.
                                // why? cause it doesn't help the uniqueness of the string anyway.
            var refreshTokenExpires = DateTime.UtcNow.AddDays(7);

            // Store the refresh token in the database
            await _userManager.SetAuthenticationTokenAsync
                (user, "MealMonkeyApi", "RefreshToken", refreshToken);

            // Return JWT token and refresh token response
            return new TokenResponse
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken,
                ExpiresIn = refreshTokenExpires
            };

        }

        public async Task<TokenResponse?> TryRefreshToken(RefreshTokenRequest requst)
        {
            // Validate the refresh token
            var user = await _userManager.FindByEmailAsync(requst.Email);
            var refreshToken = await _userManager // Can we manibulate last param to allow
                                                  // multible refresh token store eg. multible logins for each user?
                .GetAuthenticationTokenAsync(user, "MyApp", "RefreshToken");

            if (refreshToken != requst.RefreshToken || DateTime.UtcNow > requst.ExpiresIn)
            {
                // Invalid refresh token
                return null;
            }
            
            // Delete the old refresh token from the database
            await _userManager.RemoveAuthenticationTokenAsync(user, "MealMonkeyApi", "RefreshToken");

            // Generate a new access token
            return await GenerateToken(user);
        }
    }
}
