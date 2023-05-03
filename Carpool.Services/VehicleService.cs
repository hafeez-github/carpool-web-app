using System.Collections.Generic;
using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Data;
using db=Carpool.Data.DbModels;
using Carpool.Services.Contracts;
using Carpool.Models.ServiceModels;

namespace Carpool.Services
{
	public class VehicleService:IVehicleService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public VehicleService(ApplicationDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        //Post
        public async Task<Vehicle> AddVehicle(Vehicle newVehicle)
        {
            try
            {
                db.Vehicle vehicle=this.mapper.Map<db.Vehicle>(newVehicle);
                await dbContext.Vehicles.AddAsync(vehicle);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<Vehicle>(vehicle);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get All
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            try
            {
                List<db.Vehicle> vehicles = this.dbContext.Vehicles.Select(v=>v).ToList();
                List<Vehicle> vehicleModels = this.mapper.Map<List<Vehicle>>(vehicles);

                return vehicleModels;
            }

            catch (Exception ex)
            {
                throw;
            }

        }

        //Get by Id
        public async Task<Vehicle> GetVehicle(int id)
        {
            try
            {
                db.Vehicle vehicle= await dbContext.Vehicles.FindAsync(id);
                if (vehicle == null)
                {
                    throw new DataNotFoundException("The required vehicle doesn't exist");
                }
                return this.mapper.Map<Vehicle>(vehicle);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update
        public async Task<Vehicle> UpdateVehicle(int id, Vehicle editedVehicle)
        {
            try
            {
                db.Vehicle vehicle = await dbContext.Vehicles.FindAsync(id);

                if (vehicle == null)
                {
                    throw new DataNotFoundException("Vehicle corresponding to specified id doesn't exist");
                }
                vehicle.Number = editedVehicle.Number;
                vehicle.Type = editedVehicle.Type;
                vehicle.OwnerId = editedVehicle.OwnerId;

                await dbContext.SaveChangesAsync();
                return this.mapper.Map<Vehicle>(vehicle);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Delete
        public async Task<Vehicle> DeleteVehicle(int id)
        {
            try
            {
                db.Vehicle vehicle = dbContext.Vehicles.Find(id);

                if (vehicle == null)
                {
                    throw new DataNotFoundException("Vehicle corresponding to specified id doesn't exist");
                }

                dbContext.Vehicles.Remove(vehicle);
                await dbContext.SaveChangesAsync();
                return this.mapper.Map<Vehicle>(vehicle);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

