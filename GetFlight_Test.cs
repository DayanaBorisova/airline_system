using AirlineSystemApp.Entities;
using AirlineSystemApp.Models.Flight;
using AirlineSystemApp.Models.Passenger;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace AirlineSystemApp.Tests.Services
{
    public class GetFlight_Test
    {
        [Fact]
        public void GetFlight_ReturnsCorrectFlightViewModel()
        {
            // Arrange
            int flightId = 1;
            bool withPassengerList = true;

            var expectedFlightEntity = new Flight(1, "New York", "Los Angeles", 5, 200, 150);

            var expectedPassengerEntities = new List<Passenger>
            {
                new Passenger("John", "Doe"),
                new Passenger("Jane", "Smith")
            };

            var flightRepositoryMock = new Mock<IFlightRepository>();
            flightRepositoryMock.Setup(repo => repo.Get(flightId)).Returns(expectedFlightEntity);

            var passengerRepositoryMock = new Mock<IPassengerRepository>();
            passengerRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedPassengerEntities);

            var flightService = new FlightService(flightRepositoryMock.Object, passengerRepositoryMock.Object);

            // Act
            var result = flightService.GetFlight(flightId, withPassengerList);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFlightEntity.Id, result.Id);
            Assert.Equal(expectedFlightEntity.DepartureCity, result.DepartureCity);
            Assert.Equal(expectedFlightEntity.ArrivalCity, result.ArrivalCity);
            Assert.Equal(expectedFlightEntity.Duration, result.Duration);
            Assert.Equal(expectedFlightEntity.Price, result.Price);
            Assert.Equal(expectedFlightEntity.Capacity, result.Capacity);
        }
    }
}
