using AirlineSystemApp.Entities;
using Microsoft.EntityFrameworkCore;


namespace AirlineSystemApp.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Flight> Flights{get; set;}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        { }
    }
}