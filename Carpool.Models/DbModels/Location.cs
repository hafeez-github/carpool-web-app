using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Models.DbModels
{
    [Table("Location")]
    public class Location
	{
		public Location()
		{
		}

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public String Name { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public int PINCode { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }
    }
}

