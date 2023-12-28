using Xunit;
using Shouldly;
using FleetRent.Api.ValueObjects;
using FleetRent.Api.Exceptions;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class CarProductionYearTests
    {
        [Fact]
        public void CreateCarProductionYear_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = 2021;

            // Act
            var carProductionYear = new CarProductionYear(value);

            // Assert
            carProductionYear.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateCarProductionYear_WithNegativeValue_ShouldThrow()
        {
            // Arrange
            var value = -1000;

            // Act
            var exception = Record.Exception(() => new CarProductionYear(value));

            // Assert
            exception.ShouldBeOfType<InvalidProductionYearException>();
        }
    }
}