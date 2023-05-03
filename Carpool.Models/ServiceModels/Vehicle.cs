using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carpool.Utilities.Enums;

namespace Carpool.Models.ServiceModels
{
    public class Vehicle
	{
        public int Id { get; set; }

        public string Number { get; set; }

        public VehicleType Type { get; set; }

        public int OwnerId { get; set; }

        public Vehicle()
        {
        }
    }
}
