using AirlineSystemApp.Models;
using AirlineSystemApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystemApp.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public IActionResult Index()
        {
            var flights = flightService.LoadAllFlights();

            return View(flights);
        }

        public IActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult Create(CreateFlightViewModel flight)
        {
            airlineSystemService.Add(flight);

            return RedirectToAction(nameof(Index));
        }*/

       /* public IActionResult Delete(int id)
        {
            airlineSystemService.Delete(id);

            return RedirectToAction(nameof(Index));
        }*/

        /*public IActionResult Edit(int id)
        {
            var flight = airlineSystemService.Get(id);

            return View(flight);
        }*/

        /*[HttpPost]
        public IActionResult Edit(EditFlightViewModel flight)
        {
            flight.Edit(product);

            return RedirectToAction(nameof(Index));
        }*/

/*
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}