using AirlineSystemApp.Entities;
using System.Collections.Generic;

namespace AirlineSystemApp.Repositories.Interfaces
{
    public interface IFlightRepository
    {
        public void Add(Flight flight);

        public Flight Get(int id);

        public void Edit(Flight flight);

        public void Delete(int id);

        public IEnumerable<Flight> GetAll();

        public bool BookSeat(int flightId, int passengerId);
    }
}
