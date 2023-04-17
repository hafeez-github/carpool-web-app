using System.Data;
using AutoMapper;
using Carpool.Data;
using Carpool.Models.DbModels;
using Carpool.Models.RequestModels;
using Carpool.Models.ResponseModels;
using Carpool.Services.Interfaces;

namespace Carpool.Services
{
	public class BookingService:IBookingService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public BookingService(ApplicationDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BookingModel> AddBookingDetails(BookingRequest model)
        {
            try
            {
                model.BookedDateTime = DateTime.UtcNow;
                Booking booking = this.mapper.Map<Booking>(model);
                await dbContext.Bookings.AddAsync(booking);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<BookingModel>(booking);
            }
            
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BookingModel>> GetBookings(UserModel user)
        {
            List<BookingModel> bookings = new List<BookingModel>();

            List<Booking> results = this.dbContext.Bookings.Where(booking => booking.BookerId == user.Id).ToList<Booking>();

            foreach (Booking result in results)
            {
                BookingModel currentBooking = this.mapper.Map<BookingModel>(result);

                currentBooking.Booker = this.dbContext.Users.Where(user => currentBooking.BookerId == user.Id).Select(col => col.FirstName).First();
                currentBooking.ToLocation = this.dbContext.Locations.Where(loc => currentBooking.To == loc.Id).Select(col => col.Name).First();
                currentBooking.FromLocation = this.dbContext.Locations.Where(loc => currentBooking.From == loc.Id).Select(col => col.Name).First();
                bookings.Add(currentBooking);
            }

            return bookings;

        }



    }
}

