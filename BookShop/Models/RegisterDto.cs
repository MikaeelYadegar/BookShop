﻿using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password Or Confirm Password Not Match.")]
        public string ConfirmPassword { get; set; }
    }
}
  