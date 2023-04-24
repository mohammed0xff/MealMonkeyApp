namespace MealMonkey.Application.Common
{
    public class RefreshTokenRequest
    {
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
