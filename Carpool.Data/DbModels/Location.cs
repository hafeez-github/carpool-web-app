using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.DbModels
{
    [Table("Location")]
    public class Location
	{
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Name { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public int PINCode { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        public Location()
        {
        }
    }
}

