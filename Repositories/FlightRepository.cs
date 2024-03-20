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
            var flightsWithPassengers = from flight in applicationContext.Flights
                                        join flightPassenger in applicationContext.FlightPassenger
                                        on flight.Id equals flightPassenger.FlightId
                                        join passenger in applicationContext.Passengers
                                        on flightPassenger.PassengerId equals passenger.Id
                                        select new { Flight = flight, FlightPassenger = flightPassenger };

            var groupedPassengers = flightsWithPassengers
                .AsEnumerable()
                .GroupBy(fp => fp.Flight.Id)
                                                   .ToDictionary(g => g.Key, g => g.Select(fp => fp.FlightPassenger).ToList());
            
            var flightEntity = applicationContext.Flights.FirstOrDefault(f => f.Id == id);
            if (flightEntity != null)
            {
                flightEntity.FlightPassengers = groupedPassengers.ContainsKey(id) ? groupedPassengers[id] : new List<FlightPassenger>();
            }

            return flightEntity;
        }

        public void Delete(int id)
        {
            Flight flightEntity = Get(id);            
            this.applicationContext.Flights.Remove(flightEntity);
            this.applicationContext.SaveChanges();
        }

        public void Edit(Flight flight)
        {
            Flight flightEntity = Get(flight.Id);          
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

        public bool BookSeat(int flightId, int passengerId)
        {
            var flight = this.applicationContext.Flights.Find(flightId);
            if (flight == null || flight.Capacity <= 0)
            {
                return false; // Flight not found or no available seats
            }

            var passenger = this.applicationContext.Passengers.Find(passengerId);
            if (passenger == null)
            {
                return false; // Passenger not found
            }

            var reservation = new FlightPassenger
            {
                FlightId = flightId,
                Passenger = passenger
            };

            this.applicationContext.FlightPassenger.Add(reservation);
            flight.Capacity--;
            this.applicationContext.SaveChanges();
            return true;
        }
    }
}
