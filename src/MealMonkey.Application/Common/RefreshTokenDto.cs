using System.ComponentModel.DataAnnotations;

namespace MealMonkey.Application.Common
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
