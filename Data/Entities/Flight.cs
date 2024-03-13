﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineSystemApp.Entities
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartureCity { get; set; }

        [Required]
        public string ArrivalCity { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Capacity { get; set; }
        public IList<FlightPassenger> FlightPassenger { get; set; }

       /* public IEnumerable<Passenger> Passengers { get; set; }*/

        public Flight(int id, string departureCity, string arrivalCity, int duration, double price, int capacity)
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