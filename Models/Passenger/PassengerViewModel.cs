namespace AirlineSystemApp.Models.Passenger
{
    public class PassengerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PrintAllName { 
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
        

        public PassengerViewModel(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
