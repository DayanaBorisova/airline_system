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

        public Flight Get(int id)
        {
            return this.applicationContext.Flights.FirstOrDefault(flight => flight.Id == id);
        }

        public void Delete(int id)
        {
            Flight flightEntity = Get(id);
            //TODO check flight for null
            
            this.applicationContext.Flights.Remove(flightEntity);
            this.applicationContext.SaveChanges();
        }

        public void Edit(Flight flight)
        {
            Flight flightEntity = Get(flight.Id);
            //TODO check flight for null
            
            flightEntity.DepartureCity = flight.DepartureCity;
            flightEntity.ArrivalCity = flight.ArrivalCity;
            flightEntity.Duration = flight.Duration;
            flightEntity.Price = flight.Price;
            flightEntity.Capacity = flight.Capacity;

            this.applicationContext.SaveChanges();
        }

        public IEnumerable<Flight> GetAll()
        {
            return this.applicationContext.Flights.ToList();
        }
    }
}
