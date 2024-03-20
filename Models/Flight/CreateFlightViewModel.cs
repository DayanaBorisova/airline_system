namespace AirlineSystemApp.Models.Flight
{
    public class CreateFlightViewModel
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
