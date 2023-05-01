using System;
using Carpool.Models.ServiceModels;

namespace Carpool.Services.Contracts
{
	public interface IOfferService
	{
        Task<Offer> AddOfferDetails(Offer model);
        Task<List<Offer>> FindMatches(Booking booking);
        int[] ConvertStringsToIDs(string stopsAsAString);
        Task<List<Offer>> GetOffers(User user);
        
    }
}

