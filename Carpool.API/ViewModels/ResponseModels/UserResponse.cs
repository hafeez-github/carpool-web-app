﻿using System;
using Carpool.Utilities.Enums;

namespace Carpool.API.ViewModels.ResponseModels
{
	public class UserResponse
    {
		public UserResponse()
		{
		}

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public UserType Type { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public bool IsActive { get; set; }
    }
}

