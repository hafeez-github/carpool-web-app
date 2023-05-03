using System;
using System.ComponentModel.DataAnnotations;

namespace Carpool.Models.ServiceModels.Authentication
{
	public class LogIn
	{
        public string Email { get; set; }
        public string Password { get; set; }
	}
}

