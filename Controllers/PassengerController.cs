using AirlineSystemApp.Models.Passenger;
using AirlineSystemApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineSystemApp.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerService passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            this.passengerService = passengerService;
        }

       /* public IActionResult Index()
        {
            var flights = flightService.LoadAllFlights();

            return View(flights);
        }*/

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePassengerViewModel createPassengerViewModel)
        {
            passengerService.RegisterPassanger(createPassengerViewModel);

            return View();
        }
    }
}