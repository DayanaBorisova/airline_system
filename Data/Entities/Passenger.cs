using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineSystemApp.Entities
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public IList<FlightPassenger> FlightPassenger { get; set; }
        /* public IList<Flight> Flights { get; set; }*/

        public Passenger(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}