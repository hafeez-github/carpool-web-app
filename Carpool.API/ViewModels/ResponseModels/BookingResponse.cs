using System;
namespace Carpool.API.ViewModels.ResponseModels
{
	public class BookingResponse
	{
		public BookingResponse()
		{
		}

        public int Id { get; set; }

        public int BookerId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Time { get; set; }

        public DateTime Date { get; set; }

        public int SeatsRequired { get; set; }

        public string Booker { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public DateTime BookedDateTime { get; set; }

    }
}

