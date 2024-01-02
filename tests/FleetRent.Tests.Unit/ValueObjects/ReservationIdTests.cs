using FleetRent.Core.Exceptions;
using FleetRent.Core.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class ReservationIdTests
    {
        [Fact]
        public void CreateReservationId_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = Guid.NewGuid();

            // Act
            var reservationId = new ReservationId(value);

            // Assert
            reservationId.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateReservationId_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = Guid.Empty;

            // Act
            var exception = Record.Exception(() => new ReservationId(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidEntityIdException>();
        }
    }
}