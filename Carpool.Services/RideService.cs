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
        public ApiResponse<RideTransaction> ReadRideDetails(RideRequest model)
        {
            ApiResponse<RideTransaction> response = new();

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

                dbContext.RideTransactions.Add(rideTransaction);
                dbContext.SaveChanges();

                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = rideTransaction;
            }

            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message;
                response.Data = null;
            }

            return response;
        }
    }
}

