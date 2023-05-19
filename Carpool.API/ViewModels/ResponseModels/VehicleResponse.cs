using System;
using Carpool.Utilities.Enums;

namespace Carpool.API.ViewModels.ResponseModels
{
    public class VehicleResponse
    {
        public VehicleResponse()
        {
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public VehicleType Type { get; set; }

        public int OwnerId { get; set; }
    }
}

