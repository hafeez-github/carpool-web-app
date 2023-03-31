using System;
namespace Carpool.Models.RequestModels
{
	public class BookingRequest
	{
        public int BookerId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int SeatsRequired { get; set; }

        public string BookedTime { get; set; }

        public BookingRequest()
		{
		}
	}
}

