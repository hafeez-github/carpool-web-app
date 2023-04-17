using System;
namespace Carpool.Models.ResponseModels
{
	public class RideModel
	{
		public RideModel()
		{
		}

        public int Id { get; set; }

        public int BookingId { get; set; }

        public int OfferId { get; set; }

        public float Price { get; set; }

        public float Distance { get; set; }

        public DateTime TripStartDateTime { get; set; } = DateTime.UtcNow;

        public DateTime TripEndDateTime { get; set; } = DateTime.UtcNow;
    }
}

