using AirlineSystemApp.Entities;
using AirlineSystemApp.Models.Flight;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services;
using Moq;
using Xunit;

namespace AirlineSystemApp.Tests.Services
{
    public class EditFlight_Test
    {
        [Fact]
        public void Edit_ValidFlight_CallsFlightRepositoryEdit()
        {
            // Arrange
            var flightRepositoryMock = new Mock<IFlightRepository>();
            var passengerRepositoryMock = new Mock<IPassengerRepository>();
            var flightService = new FlightService(flightRepositoryMock.Object, passengerRepositoryMock.Object);
            var editFlightViewModel = new EditFlightViewModel
            {
                Id = 1,
                DepartureCity = "New York",
                ArrivalCity = "Los Angeles",
                Duration = 5,
                Price = 200,
                Capacity = 150
            };

            // Act
            flightService.Edit(editFlightViewModel);

            // Assert
            flightRepositoryMock.Verify(repo => repo.Edit(It.IsAny<Flight>()), Times.Once);
        }
    }
}
