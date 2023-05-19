using System;
using System.ComponentModel.DataAnnotations;

namespace Carpool.API.ViewModels.RequestModels
{
    public class LocationRequest
    {
        [Required(ErrorMessage = "Name required")]
        public String Name { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public int PINCode { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        public LocationRequest()
        {
        }
    }
}

