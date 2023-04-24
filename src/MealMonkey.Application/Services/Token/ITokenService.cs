using MealMonkey.Application.Common;
using MealMonkey.Domain.Entities.UserEntities;

namespace MealMonkey.Application.Services.Token
{
    public interface ITokenService
    {
        public Task<TokenResponse?> GenerateToken(User user);
        public Task<TokenResponse?> TryRefreshToken(RefreshTokenRequest requst);
    }
}
