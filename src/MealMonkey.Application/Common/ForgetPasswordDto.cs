using System.ComponentModel.DataAnnotations;

namespace MealMonkey.Application.Common
{
    public class ForgetPasswordDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}