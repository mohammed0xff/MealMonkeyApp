using MealMonkey.Application.Common;

namespace MealMonkey.Application.Services.Authantication
{
    public interface IAuthanticationService
    {
        Task<AuthanticationResponseDto> RegisterAsync(RegisterDto model);

        Task<AuthanticationResponseDto> LoginAsync(LoginDto model);

        Task<ServiceResult> ChangePasswordAsync(ChangePasswordDto model, string currentUserId);

        Task<ServiceResult> ForgetPassword(ForgetPasswordDto model);
        
        Task<ServiceResult> ResetPassword(ResetPasswordDto model);

        Task<AuthanticationResponseDto> RefreshTokenAsync(RefreshTokenDto model);

        Task<bool> RevokeTokenAsync(RefreshTokenDto model, string currentUserId);

        bool RevokeAllTokens(string currentUserId);
    }
}