using AirlineSystemApp.Models;
using AirlineSystemApp.Models.Flight;
using AirlineSystemApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AirlineSystemApp.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public IActionResult Index(string searchDepartureCity)
        {
            var flights = flightService.LoadAllFlights();

            if (!String.IsNullOrEmpty(searchDepartureCity))
            {
                flights = flights.Where(f => f.DepartureCity.Equals(searchDepartureCity));
            }

            return View(flights);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFlightViewModel flight)
        {
            flightService.AddFlight(flight);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            flightService.DeleteFlight(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var flight = flightService.GetFlight(id);

            return View(flight);
        }

        [HttpPost]
        public IActionResult Edit(EditFlightViewModel flight)
        {
            flightService.Edit(flight);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Reset()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BookSeat(int id)
        {
            var flight = flightService.GetFlight(id, true);

            return View(flight);
        }

        [HttpPost]
        public IActionResult BookSeat(BookSeatViewModel bookSeatModel)
        {
            flightService.BookSeat(bookSeatModel.FlightId, bookSeatModel.PassengerId);

            return RedirectToAction(nameof(Index));
        }


        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}