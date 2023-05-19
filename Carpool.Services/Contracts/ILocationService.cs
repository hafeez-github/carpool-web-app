using System;
using Carpool.Models.ServiceModels;

namespace Carpool.Services.Contracts
{
    public interface ILocationService
    {
        Task<Location> AddLocation(Location location);
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(int id);
        Task<Location> UpdateLocation(int id, Location editedLocation);
        Task DeleteLocation(int id);
    }
}

