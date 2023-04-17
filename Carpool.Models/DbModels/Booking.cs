using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Models.DbModels
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "BookerId required")]
        public int BookerId { get; set; }

        [Required(ErrorMessage = "From required")]
        public int From { get; set; }

        [Required(ErrorMessage = "To required")]
        public int To { get; set; }

        [Required(ErrorMessage = "Time required")]
        public string Time { get; set; }

        //[Required(ErrorMessage = "Date required")]
        public DateTime Date { get; set; }

        public int SeatsRequired { get; set; }

        public DateTime BookedDateTime { get; set; }

        //public DateTime BookingAt { get; set; } = DateTime.UtcNow;
    }
}

