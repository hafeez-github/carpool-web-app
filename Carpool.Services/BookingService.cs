using System;
using System.Data;
using Carpool.API.Exceptions;
using Carpool.Data;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Services.Interfaces;
using Carpool.Utilities;

namespace Carpool.Services
{
	public class BookingService:IBookingService
	{
        private readonly ApplicationDbContext dbContext;

        public BookingService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        //Post   
        public async Task<List<OfferTransaction>> ReadBookingDetails(BookingRequest model)
        {
            try
            {
                BookingTransaction bookingTransaction = new()
                {
                    BookerId=model.BookerId,
                    From=model.From,
                    To=model.To,
                    Time=model.Time,
                    Date = model.Date,
                    SeatsRequired =model.SeatsRequired,
                    BookedTime=model.BookedTime
                };

                await dbContext.BookingTransactions.AddAsync(bookingTransaction);
                await dbContext.SaveChangesAsync();
                
                List<OfferTransaction> matches=dbContext.OfferTransactions.Where(offer =>
                
                (offer.From == bookingTransaction.From) &&
                (
                    (offer.To == bookingTransaction.To)

                    ||

                    (CheckStop(offer.Stops, bookingTransaction))
                )
                &&
                (offer.Time == bookingTransaction.Time)&&
                (offer.Date == bookingTransaction.Date)


                ).ToList<OfferTransaction>();

                return matches;
            }
            
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public bool CheckStop(string stopsAsAString, BookingTransaction bookingTransaction)
        {
            string[] stopsAsStrings= stopsAsAString.Split(", ");

            int[] offeredStops = { }; //Stops with IDs

            for (int i=0; i< stopsAsStrings.Length;i++)
            {
                offeredStops[i] = int.Parse(stopsAsStrings[i]);
            }

            foreach (int stop in offeredStops)
            {
                if (stop == bookingTransaction.To)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

