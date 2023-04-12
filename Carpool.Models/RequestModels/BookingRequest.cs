using System;
namespace Carpool.Models.RequestModels
{
	public class BookingRequest
	{
        public int BookerId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public string Time { get; set; }

        public int SeatsRequired { get; set; }

        public string BookedTime { get; set; }

        public DateTime BookedDateTime { get; set; } = DateTime.UtcNow;

        public BookingRequest()
		{
		}
	}
}

