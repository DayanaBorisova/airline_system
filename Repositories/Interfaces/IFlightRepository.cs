using AirlineSystemApp.Entities;
using System.Collections.Generic;

namespace AirlineSystemApp.Repositories.Interfaces
{
    public interface IFlightRepository
    {
        public void Add(Flight flight);
        public IEnumerable<Flight> GetAll();
    }
}
