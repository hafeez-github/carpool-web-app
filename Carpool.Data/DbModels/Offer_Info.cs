using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Carpool.Data.DbModels
{
    [Table("Offer_Info")]
    public class Offer_Info
    {
        [Key]
        public int OfferId { get; set; }

        public string Offerer { get; set; }

        public String FromLocation { get; set; }

        public String ToLocation { get; set; }
    }
}

