using FleetRent.Core.Exceptions;
using FleetRent.Core.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class HireDateTests
    {
        [Fact]
        public void CreateHireDate_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = new DateTime(2021-01-01);

            // Act
            var hireDate = new HireDate(value);

            // Assert
            hireDate.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateHireDate_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = DateTime.MinValue;

            // Act
            var exception = Record.Exception(() => new HireDate(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidHireDateException>();
        }
    }
}