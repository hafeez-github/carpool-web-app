using AutoMapper;
using Carpool.Data;
using Carpool.Services.Contracts;
using Carpool.Models.ServiceModels;
using db = Carpool.Data.DbModels;

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

        public async Task<Booking> AddBookingDetails(Booking model)
        {
            try
            {
                model.BookedDateTime = DateTime.UtcNow;
                db.Booking booking = this.mapper.Map<db.Booking>(model);
                await dbContext.Bookings.AddAsync(booking);
                await dbContext.SaveChangesAsync();

                return this.mapper.Map<Booking>(booking);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Booking>> GetBookings(User user)
        {
            List<Booking> bookings = new List<Booking>();
            List<db.Booking> results = this.dbContext.Bookings.Where(booking => booking.BookerId == user.Id).ToList<db.Booking>();

            foreach (db.Booking result in results)
            {
                Booking currentBooking = this.mapper.Map<Booking>(result);
                currentBooking.Booker = this.dbContext.Users.Where(user => currentBooking.BookerId == user.Id).Select(col => col.FirstName).First();
                currentBooking.ToLocation = this.dbContext.Locations.Where(loc => currentBooking.To == loc.Id).Select(col => col.Name).First();
                currentBooking.FromLocation = this.dbContext.Locations.Where(loc => currentBooking.From == loc.Id).Select(col => col.Name).First();
                bookings.Add(currentBooking);
            }
            return bookings;
        }
    }
}

