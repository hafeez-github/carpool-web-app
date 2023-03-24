using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table("BookingTransaction")]
    public class BookingTransaction
	{
        public int Id { get; set; }

        public int BookerId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Time { get; set; }

        public string Date { get; set; }

        public int SeatsRequired { get; set; }

        public string BookedTime { get; set; }
    }
}

