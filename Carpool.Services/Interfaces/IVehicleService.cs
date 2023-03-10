using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IVehicleService
	{
        ApiResponse<Vehicle> AddVehicle(VehicleRequest vehicle);
        ApiResponse<IEnumerable<Vehicle>> GetVehicles();
        ApiResponse<Vehicle> GetVehicle(int id);
        ApiResponse<Vehicle> UpdateVehicle(int id, VehicleRequest editedVehicle);
        ApiResponse<Vehicle> DeleteVehicle(int id);
    }
}

