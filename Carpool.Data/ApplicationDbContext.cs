using System;
using System.Collections.Generic;
using Carpool.Data.Entities;
using Carpool.Models;
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

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<BookingTransaction> BookingTransactions { get; set; }

        public DbSet<OfferTransaction> OfferTransactions { get; set; }

        public DbSet<RideTransaction> RideTransactions { get; set; }

    }
}

