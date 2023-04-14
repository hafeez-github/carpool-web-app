using Carpool.Models.DbModels;
using Carpool.Models.RequestModels;
using Carpool.Models.ResponseModels;

namespace Carpool.Services.Interfaces
{
	public interface IBookingService
	{
        Task<BookingModel> AddBookingDetails(BookingRequest model);
        Task<List<BookingModel>> GetBookings(UserModel user);
    }
}