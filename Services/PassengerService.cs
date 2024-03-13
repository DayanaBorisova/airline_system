using AirlineSystemApp.Entities;
using AirlineSystemApp.Models.Passenger;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services.Interfaces;

namespace AirlineSystemApp.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository)
        {
            this.passengerRepository = passengerRepository;
        }

        public void RegisterPassanger(CreatePassengerViewModel passengerCreateModel)
        {
            Passenger newPassengerEntity = new Passenger(passengerCreateModel.FirstName, passengerCreateModel.LastName);
            passengerRepository.Add(newPassengerEntity);
        }
    }
}
