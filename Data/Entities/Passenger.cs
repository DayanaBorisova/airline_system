﻿using System.ComponentModel.DataAnnotations;

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

        public string PrintAllName()
        {
            return $"{FirstName} {LastName}";
        }

        public Passenger(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}