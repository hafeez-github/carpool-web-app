using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carpool.Utilities.Enums;

namespace Carpool.Models.DbModels
{
    [Table("Vehicle")]
    public class Vehicle
	{
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id required")]
        public int Id { get; set; }

        public string Number { get; set; }

        public VehicleType Type { get; set; }

        [ForeignKey("OwnerId")]
        [Required(ErrorMessage = "OwnerId required")]
        public int OwnerId { get; set; }

        public Vehicle()
        {
        }

    }
}
