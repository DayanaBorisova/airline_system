using AirlineSystemApp.Data.Entities;
using AirlineSystemApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AirlineSystemApp.Repositories
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<FlightPassenger> FlightPassenger { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            modelBuilder.Entity<FlightPassenger>()
                .HasKey(fp => new { fp.FlightId, fp.PassengerId });

            modelBuilder.Entity<FlightPassenger>()
                .HasOne<Flight>(fp => fp.Flight)
                .WithMany(f => f.FlightPassengers)
                .HasForeignKey(fp => fp.FlightId);

            modelBuilder.Entity<FlightPassenger>()
                .HasOne<Passenger>(fp => fp.Passenger)
                .WithMany(p => p.FlightPassengers)
                .HasForeignKey(fp => fp.PassengerId);
        }
    }
}