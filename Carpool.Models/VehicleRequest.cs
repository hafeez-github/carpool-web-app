using System;
namespace Carpool.Models
{
	public class VehicleRequest
	{
		public VehicleRequest()
		{
		}

        public string Number { get; set; }

        public int Type { get; set; }

        public int OwnerId { get; set; }
    }
}

