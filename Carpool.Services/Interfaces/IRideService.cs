using System;
using Carpool.Models;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IRideService
	{
        Task<RideModel> AddRideDetails(RideRequest model);
    }
}

