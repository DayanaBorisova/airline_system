using AirlineSystemApp.Models.Flight;
using System.Collections.Generic;

namespace AirlineSystemApp.Services.Interfaces
{
    public interface IFlightService
    {
        void AddFlight(CreateFlightViewModel flightCreateModel);

        FlightViewModel GetFlight(int id);

        void Edit(EditFlightViewModel flight);

        void DeleteFlight(int id);
        IEnumerable<FlightViewModel> LoadAllFlights();
        void Search();
        void BookSeat();
        void CancelBookedSeat();
        void RegisterPassanger();
    }
}
