using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carpool.Utilities.Enums;

namespace Carpool.Models.DbModels
{
    [Table("User")]
	public class User
	{
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id required")]
        public int Id { get; set; }

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

        public User()
		{

        }
	}
}

