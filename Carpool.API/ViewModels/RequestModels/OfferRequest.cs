using System;
using System.ComponentModel.DataAnnotations;

namespace Carpool.API.ViewModels.RequestModels
{
    public class OfferRequest
    {
        [Required(ErrorMessage = "BookerId required")]
        public int OffererId { get; set; }

        [Required(ErrorMessage = "From required")]
        public int From { get; set; }

        [Required(ErrorMessage = "To required")]
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

