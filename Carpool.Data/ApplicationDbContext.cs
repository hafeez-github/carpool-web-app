using Carpool.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Carpool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Ride> Rides { get; set; }

        public DbSet<Offer_Info> Offer_Infos { get; set; }

        public DbSet<Booking_Info> Booking_Infos { get; set; }

    }
}

