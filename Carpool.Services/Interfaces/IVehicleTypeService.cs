using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IVehicleTypeService
	{
        Task<VehicleType> AddVehicleType(VehicleTypeRequest vehicleType);
        Task<IEnumerable<VehicleType>> GetVehicleTypes();
        Task<VehicleType> GetVehicleType(int id);
        Task<VehicleType> UpdateVehicleType(int id, VehicleTypeRequest editedVehicleType);
        Task<VehicleType> DeleteVehicleType(int id);
    }
}

