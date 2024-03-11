using AirlineSystemApp.Entities;
using AirlineSystemApp.Models.Flight;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AirlineSystemApp.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }

        public void AddFlight(FlightViewModel flightViewModel)
        {
            var newFlightEntity = new Flight(
                flightViewModel.Id,
                flightViewModel.DepartureCity,
                flightViewModel.ArrivalCity,
                flightViewModel.Duration,
                flightViewModel.Price,
                flightViewModel.Capacity);
            flightRepository.Add(newFlightEntity);
        }

        public void BookSeat()
        {
            throw new System.NotImplementedException();
        }

        public void CancelBookedSeat()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFlight()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FlightViewModel> LoadAllFlights()
        {
            var flightEntities = this.flightRepository.GetAll();
            return flightEntities.Select(flightEntity => new FlightViewModel(
                flightEntity.Id,
                flightEntity.DepartureCity,
                flightEntity.ArrivalCity,
                flightEntity.Duration,
                flightEntity.Price,
                flightEntity.Capacity));
        }

        public void RegisterPassanger()
        {
            throw new System.NotImplementedException();
        }

        public void Search()
        {
            throw new System.NotImplementedException();
        }
    }
}
