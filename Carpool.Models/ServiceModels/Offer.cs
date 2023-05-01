using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Models.ServiceModels
{
    public class Offer
	{
        public int Id { get; set; }

        public int OffererId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Time { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public string Stops { get; set; }

        public int SeatsAvailable { get; set; }

        public DateTime OfferedDateTime { get; set; } = DateTime.UtcNow;

        public string Offerer { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }
    }
}

