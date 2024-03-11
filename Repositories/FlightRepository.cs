using AirlineSystemApp.Entities;
using AirlineSystemApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AirlineSystemApp.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationContext applicationContext;

        public FlightRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;

        }
        public void Add(Flight flight)
        {
            this.applicationContext.Flights.Add(flight);
            this.applicationContext.SaveChanges();
        }

        public IEnumerable<Flight> GetAll()
        {
            return this.applicationContext.Flights.ToList();
        }
    }
}
