using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carpool.Utilities.Enums;

namespace Carpool.Data.DbModels
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Number { get; set; }

        public VehicleType Type { get; set; }

        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }

        public Vehicle()
        {
        }

    }
}
