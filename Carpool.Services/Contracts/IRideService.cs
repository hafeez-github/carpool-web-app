using System;
using Carpool.Models.ServiceModels;

namespace Carpool.Services.Contracts
{
    public interface IRideService
    {
        Task<Ride> AddRideDetails(Ride model);
    }
}

