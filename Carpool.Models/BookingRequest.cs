using System;
namespace Carpool.Models
{
	public class BookingRequest
	{

        public int BookerId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int SeatsRequired { get; set; }

        public string BookedTime { get; set; }

        public BookingRequest()
		{
		}
	}
}

