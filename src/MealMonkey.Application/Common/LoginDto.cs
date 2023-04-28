﻿using System.ComponentModel.DataAnnotations;

namespace MealMonkey.Application.Common
{
    public class LoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}