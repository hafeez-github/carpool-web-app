using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IVehicleTypeService
	{
        ApiResponse<VehicleType> AddVehicleType(VehicleRequest vehicleType);
        ApiResponse<IEnumerable<VehicleType>> GetVehicleTypes();
        ApiResponse<VehicleType> GetVehicleType(int id);
        ApiResponse<VehicleType> UpdateVehicleType(int id, VehicleTypeRequest editedVehicleType);
        ApiResponse<VehicleType> DeleteVehicleType(int id);
    }
}

