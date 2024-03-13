using AirlineSystemApp.Models.Passenger;

namespace AirlineSystemApp.Services.Interfaces
{
    public interface IPassengerService
    {
        void RegisterPassanger(CreatePassengerViewModel passenger);
    }
}