using Carpool.Models.ServiceModels;

namespace Carpool.Services.Contracts
{
	public interface IBookingService
	{
        Task<Booking> AddBookingDetails(Booking model);
        Task<List<Booking>> GetBookings();
    }
}