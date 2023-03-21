using System;
using Carpool.Data.Entities;
using Carpool.Models;
using Carpool.Models.Authentication;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IBookingService
	{
        Task<List<OfferTransaction>> ReadBookingDetails(BookingRequest model);
    }
}