using System;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class VehicleTypeService:IVehicleTypeService
	{
        private readonly ApplicationDbContext dbContext;

        public VehicleTypeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Post
        public async Task<VehicleType> AddVehicleType(VehicleTypeRequest newVehicleType)
        {
            try
            {
                VehicleType vehicleType = new VehicleType()
                {
                    Type = newVehicleType.Type
                };

                await dbContext.VehicleTypes.AddAsync(vehicleType);
                await dbContext.SaveChangesAsync();

                return vehicleType;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        //Get All
        public async Task<IEnumerable<VehicleType>> GetVehicleTypes()
        {
            try
            {
                return dbContext.VehicleTypes;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Get by Id
        public async Task<VehicleType> GetVehicleType(int id)
        {
            try
            {
                VehicleType vehicleType= dbContext.VehicleTypes.Find(id);

                if (vehicleType == null)
                {
                    throw new DataNotFoundException("The required vehicleType doesn't exist");
                }
                return vehicleType;
            }
            catch (DataNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Update
        public async Task<VehicleType> UpdateVehicleType(int id, VehicleTypeRequest editedVehicleType)
        {
            try
            {
                VehicleType vehicleType = await dbContext.VehicleTypes.FindAsync(id);
                if (vehicleType == null)
                {
                    throw new DataNotFoundException("VehicleType corresponding to specified id doesn't exist");
                }

                vehicleType.Type = editedVehicleType.Type;

                await dbContext.SaveChangesAsync();

                return vehicleType ;

            }

            catch (DataNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        //Delete
        public async Task<VehicleType> DeleteVehicleType(int id)
        {
            try
            {
                VehicleType vehicleType = dbContext.VehicleTypes.Find(id);
                if (vehicleType == null)
                {
                    throw new DataNotFoundException("VehicleType corresponding to specified id doesn't exist");
                }

                dbContext.VehicleTypes.Remove(vehicleType);
                await dbContext.SaveChangesAsync();
                return vehicleType;

            }

            catch (DataNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}

