using System;
namespace Carpool.Models
{
	public class VehicleTypeRequest
	{
		public VehicleTypeRequest()
		{
		}

        public string Type { get; set; }

        public int SeatCapacity { get; set; }
    }
}

