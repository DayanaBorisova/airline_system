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

        public void AddFlight(CreateFlightViewModel flightCreateModel)
        {
            var newFlightEntity = new Flight(
                flightCreateModel.Id,
                flightCreateModel.DepartureCity,
                flightCreateModel.ArrivalCity,
                flightCreateModel.Duration,
                flightCreateModel.Price,
                flightCreateModel.Capacity);
            flightRepository.Add(newFlightEntity);
        }

        public void Edit(EditFlightViewModel flight)
        {
            Flight flightEntity = new Flight(
                flight.Id,
                flight.DepartureCity, 
                flight.ArrivalCity,
                flight.Duration,
                flight.Price, 
                flight.Capacity
            );

            flightRepository.Edit(flightEntity);
        }

        public FlightViewModel GetFlight(int id)
        {
            Flight flight = flightRepository.Get(id);

            return new FlightViewModel(
                flight.Id,
                flight.DepartureCity,
                flight.ArrivalCity,
                flight.Duration,
                flight.Price,
                flight.Capacity
                );
        }

        public void DeleteFlight(int id)
        {
            flightRepository.Delete(id);
        }

        public void BookSeat()
        {
            throw new System.NotImplementedException();
        }

        public void CancelBookedSeat()
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
                flightEntity.Capacity,
               // flightEntity.Capacity == flightEntity.Passengers?.Count
               false
                ));
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
