using AirlineSystemApp.Entities;
using System.Collections.Generic;

namespace AirlineSystemApp.Repositories.Interfaces
{
    public interface IPassengerRepository
    {
        public void Add(Passenger passenger);

        public Passenger Get(int id);

        public IEnumerable<Passenger> GetAll();
    }
}
