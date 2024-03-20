using AirlineSystemApp.Models.Passenger;
using System.Collections.Generic;

namespace AirlineSystemApp.Models.Flight
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public bool IsFullyBooked{ get;}

        public readonly IList<Passenger.PassengerViewModel> PassengerViewModels;

        public string? SearchDeparetureCity { get; set; }

        public FlightViewModel(int id, string departureCity, string arrivalCity, int duration, decimal price, int capacity, bool isFullyBooked, IList<Passenger.PassengerViewModel> passengerViewModels)
        {
            this.Id = id;
            this.DepartureCity = departureCity;
            this.ArrivalCity = arrivalCity;
            this.Duration = duration;
            this.Price = price;
            this.Capacity = capacity;
            this.IsFullyBooked = isFullyBooked;
            this.PassengerViewModels = passengerViewModels;
        }

        public FlightViewModel(int id, string departureCity, string arrivalCity, int duration, decimal price, int capacity, bool isFullyBooked)
        {
            this.Id = id;
            this.DepartureCity = departureCity;
            this.ArrivalCity = arrivalCity;
            this.Duration = duration;
            this.Price = price;
            this.Capacity = capacity;
            this.IsFullyBooked = isFullyBooked;
        }

    public FlightViewModel(int id, string departureCity, string arrivalCity, int duration, decimal price, int capacity)
        {
            this.Id = id;
            this.DepartureCity = departureCity;
            this.ArrivalCity = arrivalCity;
            this.Duration = duration;
            this.Price = price;
            this.Capacity = capacity;
        }
    }
}
