using System;
namespace Carpool.Models
{
	public class OfferRequest
	{
        public int OffererId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Time { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public string Stops { get; set; }

        public int SeatsAvailable { get; set; }

        public DateTime OfferedDateTime { get; set; } = DateTime.UtcNow;

        public OfferRequest()
		{
		}
	}
}

