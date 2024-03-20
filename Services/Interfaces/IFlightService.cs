using AirlineSystemApp.Models.Flight;
using System.Collections.Generic;

namespace AirlineSystemApp.Services.Interfaces
{
    public interface IFlightService
    {
        void AddFlight(CreateFlightViewModel flightCreateModel);
        FlightViewModel GetFlight(int id, bool withPassengerList = false);

        void Edit(EditFlightViewModel flight);

        void DeleteFlight(int id);
        IEnumerable<FlightViewModel> LoadAllFlights();
        void Search();
        void BookSeat(int flightId, int passengerId);
        void CancelBookedSeat();
        void RegisterPassanger();
    }
}
