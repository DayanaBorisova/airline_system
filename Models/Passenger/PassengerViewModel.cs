namespace AirlineSystemApp.Models.Passenger
{
    public class PassengerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PrintAllName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
