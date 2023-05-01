using System;
using System.ComponentModel.DataAnnotations;
using Carpool.Utilities.Enums;

namespace Carpool.API.ViewModels.RequestModels
{
	public class UserRequest
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public UserType Type { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public string Mobile { get; set; }

        public bool IsActive { get; set; }

        public UserRequest()
        {
        }
    }
}

