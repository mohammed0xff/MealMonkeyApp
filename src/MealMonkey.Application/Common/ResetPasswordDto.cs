using System.ComponentModel.DataAnnotations;

namespace MealMonkey.Application.Common
{
    public class ResetPasswordDto
    {
        [Required]
        public string OTP { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
