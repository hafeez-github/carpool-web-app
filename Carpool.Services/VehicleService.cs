using AutoMapper;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;

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
        public async Task<VehicleModel> AddVehicle(VehicleRequest newVehicle)
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

                return this.mapper.Map<VehicleModel>(vehicle);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get All
        public async Task<IEnumerable<VehicleModel>> GetVehicles()
        {
            try
            {
                List<Vehicle> vehicles = this.dbContext.Vehicles.Select(v=>v).ToList();
                return this.mapper.Map<List<VehicleModel>>(vehicles);
            }

            catch (Exception ex)
            {
                throw;
            }

        }

        //Get by Id
        public async Task<VehicleModel> GetVehicle(int id)
        {
            try
            {
                Vehicle vehicle= await dbContext.Vehicles.FindAsync(id);

                if (vehicle == null)
                {
                    throw new DataNotFoundException("The required vehicle doesn't exist");
                }
                return this.mapper.Map<VehicleModel>(vehicle);
            }

            catch (DataNotFoundException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }

        }

        //Update
        public async Task<VehicleModel> UpdateVehicle(int id, VehicleRequest editedVehicle)
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
                return this.mapper.Map<VehicleModel>(vehicle);

            }

            catch (DataNotFoundException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        //Delete
        public async Task<VehicleModel> DeleteVehicle(int id)
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
                return this.mapper.Map<VehicleModel>(vehicle);

            }

            catch (DataNotFoundException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}

