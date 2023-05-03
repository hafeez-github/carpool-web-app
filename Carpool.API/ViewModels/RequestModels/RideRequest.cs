using System;
using System.ComponentModel.DataAnnotations;

namespace Carpool.API.ViewModels.RequestModels
{
	public class RideRequest
	{
		public RideRequest()
		{
		}

        [Required(ErrorMessage = "BookingId required")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "OfferId required")]
        public int OfferId { get; set; }

        public int Price { get; set; }

        public int Distance { get; set; }

        public DateTime TripStartDateTime { get; set; } = DateTime.UtcNow;

        public DateTime TripEndDateTime { get; set; } = DateTime.UtcNow;
    }
}

