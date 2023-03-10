using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table("UserType")]
    public class UserType
	{
		public int Id { get; set; }

		public string Type { get; set; }

        public UserType()
        {
        }

    }
}

