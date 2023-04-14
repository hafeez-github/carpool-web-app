using System;
using Carpool.Models;
using Carpool.Models.ResponseModels;
using Carpool.Utilities;

namespace Carpool.Services.Interfaces
{
	public interface IOfferService
	{
        Task<OfferModel> AddOfferDetails(OfferRequest model);
        Task<List<OfferModel>> FindMatches(BookingModel booking);
        int[] ConvertStringsToIDs(string stopsAsAString);
        Task<List<OfferModel>> GetOffers(UserModel user);
        
    }
}

