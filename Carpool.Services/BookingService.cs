using AutoMapper;
using Carpool.Data;
using Carpool.Services.Contracts;
using Carpool.Models.ServiceModels;
using db = Carpool.Data.DbModels;
using Microsoft.AspNetCore.Http;

namespace Carpool.Services
{
	public class BookingService:IBookingService
	{
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private IHttpContextAccessor httpContextAccessor;

        public BookingService(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
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

        public async Task<List<Booking>> GetBookings()
        {
            List<Booking> bookings = new List<Booking>();
            int userId = Convert.ToInt32(this.httpContextAccessor.HttpContext.User.FindFirst("id").Value);

            List<db.Booking> results = this.dbContext.Bookings.Where(booking => booking.BookerId == userId).ToList<db.Booking>();

            foreach (db.Booking result in results)
            {
                Booking currentBooking = this.mapper.Map<Booking>(result);
                db.Booking_Info temp = this.dbContext.Booking_Infos.Where(booking => booking.BookingId == result.Id).First();
                currentBooking = this.mapper.Map(temp, currentBooking);
                bookings.Add(currentBooking);
            }
            return bookings;
        }
    }
}

