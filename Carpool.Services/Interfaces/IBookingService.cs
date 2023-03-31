using Carpool.Models.DbModels;
using Carpool.Models.RequestModels;
using Carpool.Models.ResponseModels;

namespace Carpool.Services.Interfaces
{
	public interface IBookingService
	{
        Task<List<OfferModel>> AddBookingDetails(BookingRequest model);
        int[] ConvertStringsToIDs(string stopsAsAString);
    }
}