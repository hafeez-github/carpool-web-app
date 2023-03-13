using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table("RideTransaction")]
    public class RideTransaction
	{
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int OfferId { get; set; }

        public string TripStart { get; set; }

        public string TripEnd { get; set; }

        public float Price { get; set; }

        public float Distance { get; set; }
    }
}
    
