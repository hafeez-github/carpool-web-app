using AutoMapper;
using Carpool.Data;
using db=Carpool.Data.DbModels;
using Carpool.Models.ServiceModels;
using Carpool.Services.Contracts;

namespace Carpool.Services
{
	public class RideService:IRideService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public RideService(ApplicationDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Ride> AddRideDetails(Ride model)
        {
            try
            {
                model.TripStartDateTime = DateTime.UtcNow;
                model.TripEndDateTime = DateTime.UtcNow;
                db.Ride ride = this.mapper.Map<db.Ride>(model);
                await dbContext.Rides.AddAsync(ride);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<Ride>(ride);
            }

            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

