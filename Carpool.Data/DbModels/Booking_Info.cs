using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.DbModels
{
    [Table("Booking_Info")]
    public class Booking_Info
	{
        [Key]
        public int BookingId { get; set; }

        public string Booker { get; set; }

        public String FromLocation { get; set; }

        public String ToLocation { get; set; }
	}
}
