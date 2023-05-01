using System;
using System.ComponentModel.DataAnnotations;

namespace Carpool.API.ViewModels.RequestModels
{
	public class BookingRequest
	{
        [Required(ErrorMessage = "BookerId required")]
        public int BookerId { get; set; }

        [Required(ErrorMessage = "From required")]
        public int From { get; set; }

        [Required(ErrorMessage = "To required")]
        public int To { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time required")]
        public string Time { get; set; }

        public int SeatsRequired { get; set; }

        public DateTime BookedDateTime { get; set; }

        public BookingRequest()
		{
		}
	}
}

