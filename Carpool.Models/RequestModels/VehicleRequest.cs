using System;
using Carpool.Utilities.Enums;

namespace Carpool.Models
{
	public class VehicleRequest
	{
		public VehicleRequest()
		{
		}

        public string Number { get; set; }

        public VehicleType Type { get; set; }

        public int OwnerId { get; set; }
    }
}

