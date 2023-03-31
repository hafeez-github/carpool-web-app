using System;
using Carpool.Models;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface ILocationService
	{
        Task<LocationModel> AddLocation(LocationRequest location);
        Task<IEnumerable<LocationModel>> GetLocations();
        Task<LocationModel> GetLocation(int id);
        Task<LocationModel> UpdateLocation(int id, LocationRequest editedLocation);
        Task<LocationModel> DeleteLocation(int id);
    }
}

