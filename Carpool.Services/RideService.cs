using System;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class RideService:IRideService
	{
        private readonly ApplicationDbContext dbContext;

        public RideService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        //Post   
        public async Task<RideTransaction> ReadRideDetails(RideRequest model)
        {
            try
            {
                RideTransaction rideTransaction = new()
                {
                    BookingId = model.BookingId,
                    OfferId = model.OfferId,
                    TripStart = model.TripStart,
                    TripEnd=model.TripEnd,
                    Price=model.Price,
                    Distance=model.Distance
                };

                await dbContext.RideTransactions.AddAsync(rideTransaction);
                await dbContext.SaveChangesAsync();

                return rideTransaction;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

