using AirlineSystemApp.Models.Flight;
using System.Collections.Generic;

namespace AirlineSystemApp.Services.Interfaces
{
    public interface IFlightService
    {
        void AddFlight(FlightViewModel flightViewModel);
        IEnumerable<FlightViewModel> LoadAllFlights();
        void Search();
        void BookSeat();
        void CancelBookedSeat();
        
        void DeleteFlight();
        void RegisterPassanger();
    }
}
