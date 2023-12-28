using Xunit;
using Shouldly;
using FleetRent.Api.ValueObjects;
using FleetRent.Api.Exceptions;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class CarIdTests
    {
        [Fact]
        public void CreateCarId_WhenIdIsEmpty_ThrowsInvalidEntityIdException()
        {
            // Arrange
            var id = System.Guid.Empty;

            // Act
            var exception = Record.Exception(() => new CarId(id));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidEntityIdException>();
        }

        [Fact]
        public void CreateCarId_WhenIdIsValid_ReturnsCarId()
        {
            // Arrange
            var id = System.Guid.NewGuid();

            // Act
            var carId = new CarId(id);

            // Assert
            carId.ShouldNotBeNull();
            carId.Value.ShouldBe(id);
        }
    }
}