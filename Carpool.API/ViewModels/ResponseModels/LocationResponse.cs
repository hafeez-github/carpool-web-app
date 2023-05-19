using System;
namespace Carpool.API.ViewModels.ResponseModels
{
    public class LocationResponse
    {
        public LocationResponse()
        {
        }

        public int Id { get; set; }

        public String Name { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String Country { get; set; }

        public int PINCode { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }
    }
}

