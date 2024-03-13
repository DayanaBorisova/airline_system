namespace AirlineSystemApp.Models.Flight
{
    public class EditFlightViewModel
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
