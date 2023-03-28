using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table("VehicleType")]
    public class VehicleType
	{
		public int Id { get; set; }

        public string Type { get; set; }

        public int SeatCapacity { get; set; }

        public VehicleType()
        {
        }
    }
}

