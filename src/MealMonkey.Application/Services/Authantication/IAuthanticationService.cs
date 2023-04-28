using MealMonkey.Application.Common;
using MealMonkey.Application.Settings;

namespace MealMonkey.Application.Services.Authantication
{
    public interface IAuthanticationService
    {
        Task<AuthanticationResponseDto> RegisterAsync(RegisterDto model);

        Task<AuthanticationResponseDto> LoginAsync(LoginDto model);

        Task<ServiceResult> ChangePasswordAsync(ChangePasswordDto model, string currentUserId);

        //Task<AuthanticationResponseDto> ForgetPassword(LoginDto model);

        Task<AuthanticationResponseDto> RefreshTokenAsync(RefreshTokenDto model);

        Task<bool> RevokeTokenAsync(RefreshTokenDto model, string currentUserId);

        bool RevokeAllTokens(string currentUserId);
    }
}