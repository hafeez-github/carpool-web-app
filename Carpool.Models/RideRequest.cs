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

        public float Price { get; set; }

        public float Distance { get; set; }
    }
}

