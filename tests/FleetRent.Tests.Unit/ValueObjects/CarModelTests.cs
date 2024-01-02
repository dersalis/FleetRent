using FleetRent.Core.Exceptions;
using FleetRent.Core.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class CarModelTests
    {
        [Fact]
        public void CreateCarModel_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = "Audi A4";

            // Act
            var carModel = new CarModel(value);

            // Assert
            carModel.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateCarModel_WithEmptyValue_ShouldThrow()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var exception = Record.Exception(() => new CarModel(value));

            // Assert
            exception.ShouldBeOfType<InvalidCarModelException>();
        }

        [Fact]
        public void CreateCarModel_WithNullValue_ShouldThrow()
        {
            // Arrange
            string value = null;

            // Act
            var exception = Record.Exception(() => new CarModel(value));

            // Assert
            exception.ShouldBeOfType<InvalidCarModelException>();
        }
    }
}