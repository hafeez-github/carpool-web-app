using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table("OfferTransaction")]
    public class OfferTransaction
	{
        public int Id { get; set; }

        public int OffererId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int SeatsAvailable { get; set; }

        public string OfferedTime { get; set; }
    }
}

