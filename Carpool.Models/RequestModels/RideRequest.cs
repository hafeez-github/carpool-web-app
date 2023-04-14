using System;
namespace Carpool.Models
{
	public class RideRequest
	{
		public RideRequest()
		{
		}
        public int BookingId { get; set; }

        public int OfferId { get; set; }

        public string TripStart { get; set; }

        public string TripEnd { get; set; }

        public int Price { get; set; }

        public int Distance { get; set; }

        public DateTime TripStartDateTime { get; set; } = DateTime.UtcNow;

        public DateTime TripEndDateTime { get; set; } = DateTime.UtcNow;
    }
}

