
namespace AirlineSystemApp.Entities
{
    public class FlightPassenger
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}