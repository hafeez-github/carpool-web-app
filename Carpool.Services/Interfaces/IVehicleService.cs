using System;
using Carpool.Models;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IVehicleService
	{
        Task<VehicleModel> AddVehicle(VehicleRequest vehicle);
        Task<IEnumerable<VehicleModel>> GetVehicles();
        Task<VehicleModel> GetVehicle(int id);
        Task<VehicleModel> UpdateVehicle(int id, VehicleRequest editedVehicle);
        Task<VehicleModel> DeleteVehicle(int id);
    }
}

