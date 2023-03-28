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
        public async Task<OfferTransaction> ReadOfferDetails(OfferRequest model)
        {
            try
            {
                OfferTransaction offerTransaction = new()
                {
                    OffererId = model.OffererId,
                    From = model.From,
                    To = model.To,
                    Time = model.Time,
                    Date= model.Date,
                    SeatsAvailable = model.SeatsAvailable,
                    Stops=model.Stops,
                    OfferedTime = model.OfferedTime
                };

                await dbContext.OfferTransactions.AddAsync(offerTransaction);
                await dbContext.SaveChangesAsync();

                return offerTransaction;
            }

            catch (Exception ex)
            {
                throw ex;
            }

           
        }
    }
}

