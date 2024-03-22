using AirlineSystemApp.Entities;
using AirlineSystemApp.Models.Passenger;
using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services;
using Moq;
using Xunit;

namespace AirlineSystemApp.Tests.Services
{
    public class RegisterPassenger_Test
    {
        [Fact]
        public void RegisterPassanger_AddsPassengerToRepository()
        {
            // Arrange
            var passengerCreateModel = new CreatePassengerViewModel
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var passengerRepositoryMock = new Mock<IPassengerRepository>();
            var passengerService = new PassengerService(passengerRepositoryMock.Object);

            // Act
            passengerService.RegisterPassanger(passengerCreateModel);

            // Assert
            passengerRepositoryMock.Verify(repo => repo.Add(It.IsAny<Passenger>()), Times.Once);
        }
    }
}
