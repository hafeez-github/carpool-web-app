using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IVehicleService
	{
        Task<Vehicle> AddVehicle(VehicleRequest vehicle);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicle(int id);
        Task<Vehicle> UpdateVehicle(int id, VehicleRequest editedVehicle);
        Task<Vehicle> DeleteVehicle(int id);
    }
}

