using Xunit;
using Shouldly;
using FleetRent.Api.ValueObjects;
using FleetRent.Api.Exceptions;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class CarMileageTests
    {
        [Fact]
        public void CrateCarMileage_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = 1000;

            // Act
            var carMileage = new CarMileage(value);

            // Assert
            carMileage.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateCarMileage_WithNegativeValue_ShouldThrow()
        {
            // Arrange
            var value = -1000;

            // Act
            var exception = Record.Exception(() => new CarMileage(value));

            // Assert
            exception.ShouldBeOfType<InvalidMileageException>();
        }
    }
}