using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface ILocationService
	{
        Task<Location> AddLocation(LocationRequest location);
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(int id);
        Task<Location> UpdateLocation(int id, LocationRequest editedLocation);
        Task<Location> DeleteLocation(int id);
    }
}

