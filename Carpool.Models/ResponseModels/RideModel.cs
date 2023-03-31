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

        public string TripStart { get; set; }

        public string TripEnd { get; set; }

        public float Price { get; set; }

        public float Distance { get; set; }
    }
}

