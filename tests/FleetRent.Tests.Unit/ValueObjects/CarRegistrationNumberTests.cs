using Xunit;
using Shouldly;
using FleetRent.Api.ValueObjects;
using FleetRent.Api.Exceptions;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class CarRegistrationNumberTests
    {
        [Fact]
        public void CreateCarRegistrationNumber_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = "ABC1234";

            // Act
            var carRegistrationNumber = new CarRegistrationNumber(value);

            // Assert
            carRegistrationNumber.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateCarRegistrationNumber_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = "ABC123";

            // Act
            var exception = Record.Exception(() => new CarRegistrationNumber(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidRegistrationNumberException>();
        }

        [Fact]
        public void CreateCarRegistrationNumber_WithNullValue_ShouldThrow()
        {
            // Arrange
            string value = null;

            // Act
            var exception = Record.Exception(() => new CarRegistrationNumber(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyRegistrationNumberException>();
        }

        [Fact]
        public void CreateCarRegistrationNumber_WithEmptyValue_ShouldThrow()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var exception = Record.Exception(() => new CarRegistrationNumber(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyRegistrationNumberException>();
        }

        [Fact]
        public void CreateCarRegistrationNumber_WithWhitespaceValue_ShouldThrow()
        {
            // Arrange
            var value = " ";

            // Act
            var exception = Record.Exception(() => new CarRegistrationNumber(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyRegistrationNumberException>();
        }
    }
}