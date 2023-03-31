using System;
using Carpool.Utilities.Enums;

namespace Carpool.Models.ResponseModels
{
	public class VehicleModel
	{
		public VehicleModel()
		{
		}

        public int Id { get; set; }

        public string Number { get; set; }

        public VehicleType Type { get; set; }

        public int OwnerId { get; set; }
    }
}

