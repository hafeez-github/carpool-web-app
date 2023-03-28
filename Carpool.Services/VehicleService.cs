using System;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class VehicleService:IVehicleService
	{
        private readonly ApplicationDbContext dbContext;

        public VehicleService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        //Post
        public async Task<Vehicle> AddVehicle(VehicleRequest newVehicle)
        {
            try
            {
                Vehicle vehicle = new Vehicle()
                {
                    Number = newVehicle.Number,
                    Type = newVehicle.Type,
                    OwnerId = newVehicle.OwnerId
                };

                await dbContext.Vehicles.AddAsync(vehicle);
                await dbContext.SaveChangesAsync();

                return vehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get All
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            try
            {
                return dbContext.Vehicles;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Get by Id
        public async Task<Vehicle> GetVehicle(int id)
        {
            try
            {
                Vehicle vehicle= await dbContext.Vehicles.FindAsync(id);

                if (vehicle == null)
                {
                    throw new DataNotFoundException("The required vehicle doesn't exist");
                }
                return vehicle;
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
        public async Task<Vehicle> UpdateVehicle(int id, VehicleRequest editedVehicle)
        {
            try
            {
                Vehicle vehicle = await dbContext.Vehicles.FindAsync(id);

                if (vehicle == null)
                {
                    throw new DataNotFoundException("Vehicle corresponding to specified id doesn't exist");
                }

                vehicle.Number = editedVehicle.Number;
                vehicle.Type = editedVehicle.Type;
                vehicle.OwnerId = editedVehicle.OwnerId;

                await dbContext.SaveChangesAsync();
                return vehicle;

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
        public async Task<Vehicle> DeleteVehicle(int id)
        {
            try
            {
                Vehicle vehicle = dbContext.Vehicles.Find(id);

                if (vehicle == null)
                {
                    throw new DataNotFoundException("Vehicle corresponding to specified id doesn't exist");
                }

                dbContext.Vehicles.Remove(vehicle);
                await dbContext.SaveChangesAsync();
                return vehicle;

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

