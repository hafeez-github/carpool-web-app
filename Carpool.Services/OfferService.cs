using System;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class OfferService:IOfferService
	{
        private readonly ApplicationDbContext dbContext;

        public OfferService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        //Post   
        public ApiResponse<OfferTransaction> ReadOfferDetails(OfferRequest model)
        {
            ApiResponse<OfferTransaction> response = new();

            try
            {
                OfferTransaction offerTransaction = new()
                {
                    OffererId = model.OffererId,
                    From = model.From,
                    To = model.To,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    SeatsAvailable = model.SeatsAvailable,
                    OfferedTime = model.OfferedTime
                };

                dbContext.OfferTransactions.Add(offerTransaction);
                dbContext.SaveChanges();

                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = offerTransaction;
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

