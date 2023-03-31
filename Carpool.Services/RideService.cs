using AutoMapper;
using Carpool.Data;
using Carpool.Models;
using Carpool.Models.DbModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;

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

        //Post   
        public async Task<RideModel> AddRideDetails(RideRequest model)
        {
            try
            {
                Ride ride = new()
                {
                    BookingId = model.BookingId,
                    OfferId = model.OfferId,
                    TripStart = model.TripStart,
                    TripEnd=model.TripEnd,
                    Price=model.Price,
                    Distance=model.Distance
                };

                await dbContext.Rides.AddAsync(ride);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<RideModel>(ride);
            }

            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

