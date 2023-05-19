using System;
using System.ComponentModel.DataAnnotations;

namespace Carpool.API.ViewModels.Authentication
{
    public class LogIn
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

