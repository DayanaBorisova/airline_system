using AirlineSystemApp.Entities;
using AirlineSystemApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AirlineSystemApp.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationContext applicationContext;

        public PassengerRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;

        }
        public void Add(Passenger passenger)
        {
            this.applicationContext.Passengers.Add(passenger);
            this.applicationContext.SaveChanges();
        }

        public Passenger Get(int id)
        {
            return this.applicationContext.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        }

        public IEnumerable<Passenger> GetAll()
        {
            return this.applicationContext.Passengers.ToList();
        }
    }
}
