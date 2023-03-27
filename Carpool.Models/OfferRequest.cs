using System;
namespace Carpool.Models
{
	public class OfferRequest
	{
        public int OffererId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Time { get; set; }

        public string Date { get; set; }

        //public string Stops { get; set; }

        public int SeatsAvailable { get; set; }

        public string OfferedTime { get; set; }

        public OfferRequest()
		{
		}
	}
}

