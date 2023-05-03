using System;
using Carpool.Models.ServiceModels;

namespace Carpool.Services.Contracts
{
	public interface IVehicleService
	{
        Task<Vehicle> AddVehicle(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicle(int id);
        Task<Vehicle> UpdateVehicle(int id, Vehicle editedVehicle);
        Task<Vehicle> DeleteVehicle(int id);
    }
}

