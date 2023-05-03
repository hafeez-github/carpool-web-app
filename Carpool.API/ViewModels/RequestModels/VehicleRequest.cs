using System;
using System.ComponentModel.DataAnnotations;
using Carpool.Utilities.Enums;

namespace Carpool.API.ViewModels.RequestModels
{
	public class VehicleRequest
	{
		public VehicleRequest()
		{
		}

        public string Number { get; set; }

        public VehicleType Type { get; set; }

        [Required(ErrorMessage = "OwnerId required")]
        public int OwnerId { get; set; }
    }
}

