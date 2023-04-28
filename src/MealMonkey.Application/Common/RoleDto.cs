using System.ComponentModel.DataAnnotations;

namespace MealMonkey.Application.Common
{
    public class RoleDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}