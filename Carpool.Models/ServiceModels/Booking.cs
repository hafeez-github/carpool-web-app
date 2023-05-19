using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Models.ServiceModels
{
    public class Booking
    {

        public int Id { get; set; }

        public int BookerId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Time { get; set; }

        public DateTime Date { get; set; }

        public int SeatsRequired { get; set; }

        public DateTime BookedDateTime { get; set; }

        public string Booker { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

    }
}

