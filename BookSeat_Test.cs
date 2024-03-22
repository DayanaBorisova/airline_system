using AirlineSystemApp.Repositories.Interfaces;
using AirlineSystemApp.Services;
using Moq;
using Xunit;

namespace AirlineSystemApp.Tests.Services
{
    public class BookSeat_Test
    {
        [Fact]
        public void BookSeat_Valid()
        {
            // Arrange
            var flightRepositoryMock = new Mock<IFlightRepository>();
            var passengerRepositoryMock = new Mock<IPassengerRepository>();
            var flightService = new FlightService(flightRepositoryMock.Object, passengerRepositoryMock.Object);
            int flightId = 1;
            int passengerId = 101;

            // Act
            flightService.BookSeat(flightId, passengerId);

            // Assert
            flightRepositoryMock.Verify(repo => repo.BookSeat(flightId, passengerId), Times.Once);
        }
    }
}
