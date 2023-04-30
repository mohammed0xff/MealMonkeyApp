using System.ComponentModel.DataAnnotations;

namespace MealMonkey.Application.Common
{
    public class RegisterDto
    {
        [Required, StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; }


        [Required, StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}