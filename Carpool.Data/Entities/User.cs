using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table("User")]
	public class User
	{

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public int UserType { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public bool IsActive { get; set; }

        public User()
		{

        }
	}
}

