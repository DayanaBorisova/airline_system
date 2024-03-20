using AirlineSystemApp.Entities;
using AirlineSystemApp.Models.Flight;
using AirlineSystemApp.Models.Passenger;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AirlineSystemApp.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository flightRepository;
        private readonly IPassengerRepository passengerRepository;

        public FlightService(IFlightRepository flightRepository, IPassengerRepository passengerRepository)
        {
            this.flightRepository = flightRepository;
            this.passengerRepository = passengerRepository;
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

        public FlightViewModel GetFlight(int id, bool withPassengerList)
        {
            var flight = flightRepository.Get(id);

            if (withPassengerList)
            {
                IList<Passenger> passengerEntities = passengerRepository.GetAll().ToList();
                IList<PassengerViewModel> passengerViewModels = passengerEntities.Select(passengerEntity => new PassengerViewModel(
                    passengerEntity.Id,
                    passengerEntity.FirstName,
                    passengerEntity.LastName
                 )).ToList();

                return new FlightViewModel(
                    flight.Id,
                    flight.DepartureCity,
                    flight.ArrivalCity,
                    flight.Duration,
                    flight.Price,
                    flight.Capacity,
                    (flight.Capacity > 0) ? false : true,
                    passengerViewModels
                    );
            }
            else {
                return new FlightViewModel(
                flight.Id,
                flight.DepartureCity,
                flight.ArrivalCity,
                flight.Duration,
                flight.Price,
                flight.Capacity
                );
            }
        }

        public void DeleteFlight(int id)
        {
            flightRepository.Delete(id);
        }

        public void BookSeat(int flightId, int passengerId)
        {
            /*Flight flight = flightRepository.Get(flightId);
            Passenger passenger = passengerRepository.Get(passengerId);

            FlightPassenger flightPassenger = new FlightPassenger
            {
                FlightId = flight.Id,
                PassengerId = passenger.Id
            };
            flight.FlightPassengers.Add(flightPassenger);*/

            this.flightRepository.BookSeat(flightId, passengerId);
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
                (flightEntity.Capacity > 0)? false : true
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
