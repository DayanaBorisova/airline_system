﻿using AirlineSystemApp.Entities;
using Microsoft.EntityFrameworkCore;


namespace AirlineSystemApp.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<FlightPassenger> FlightPassenger { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightPassenger>()
                .HasKey(fp => new { fp.FlightId, fp.PassengerId });

            modelBuilder.Entity<FlightPassenger>()
                .HasOne<Flight>(fp => fp.Flight)
                .WithMany(f => f.FlightPassenger)
                .HasForeignKey(fp => fp.FlightId);

            modelBuilder.Entity<FlightPassenger>()
                .HasOne<Passenger>(fp => fp.Passenger)
                .WithMany(p => p.FlightPassenger)
                .HasForeignKey(fp => fp.PassengerId);
        }
    }
}