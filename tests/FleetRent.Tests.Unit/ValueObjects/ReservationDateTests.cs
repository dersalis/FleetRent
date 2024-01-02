using FleetRent.Core.Exceptions;
using FleetRent.Core.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class ReservationDateTests
    {
        [Fact]
        public void CreateReservationDate_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = new DateTime(2021-01-01);

            // Act
            var reservationDate = new ReservationDate(value);

            // Assert
            reservationDate.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateReservationDate_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = DateTime.MinValue;

            // Act
            var exception = Record.Exception(() => new ReservationDate(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidReservationDateException>();
        }
    }
}