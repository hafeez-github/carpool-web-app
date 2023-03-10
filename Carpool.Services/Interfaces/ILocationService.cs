using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface ILocationService
	{
        ApiResponse<Location> AddLocation(LocationRequest location);
        ApiResponse<IEnumerable<Location>> GetLocations();
        ApiResponse<Location> GetLocation(int id);
        ApiResponse<Location> UpdateLocation(int id, LocationRequest editedLocation);
        ApiResponse<Location> DeleteLocation(int id);
    }
}

