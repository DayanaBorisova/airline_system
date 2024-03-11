namespace AirlineSystemApp.Models.Flight
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }

        public int IsFullyBooked()
        {
            if (this.Capacity == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public FlightViewModel(int id, string departureCity, string arrivalCity, int duration, double price, int capacity)
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
