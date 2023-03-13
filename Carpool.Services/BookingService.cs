using System;
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
        public ApiResponse<BookingTransaction> ReadBookingDetails(BookingRequest model)
        {
            ApiResponse<BookingTransaction> response = new();

            try
            {
                BookingTransaction bookingTransaction = new()
                {
                    BookerId=model.BookerId,
                    From=model.From,
                    To=model.To,
                    StartTime=model.StartTime,
                    EndTime=model.EndTime,
                    SeatsRequired=model.SeatsRequired,
                    BookedTime=model.BookedTime
                };

                dbContext.BookingTransactions.Add(bookingTransaction);
                dbContext.SaveChanges();

                

                response = new(201, "Success", true);
                response.Message = "User succesfully added";
                response.Data = bookingTransaction;
            }
            
            catch (Exception ex)
            {
                response = new(400, "Failure", false);
                response.Message = "Error! " + ex.Message ;
                response.Data = null;
            }

            return response;
        }
    }
}

