using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Models.Authentication;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IBookingService
	{
        ApiResponse<BookingTransaction> ReadBookingDetails(BookingRequest model);
    }
}

