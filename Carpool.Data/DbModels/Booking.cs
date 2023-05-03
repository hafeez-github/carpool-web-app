using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.DbModels
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int BookerId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Time { get; set; }

        public DateTime Date { get; set; }

        public int SeatsRequired { get; set; }

        public DateTime BookedDateTime { get; set; }

    }
}

