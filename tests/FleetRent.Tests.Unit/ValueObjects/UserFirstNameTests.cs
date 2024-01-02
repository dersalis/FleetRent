using FleetRent.Core.Exceptions;
using FleetRent.Core.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class UserFirstNameTests
    {
        [Fact]
        public void CreateUserFirstName_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = "John";

            // Act
            var userFirstName = new UserFirstName(value);

            // Assert
            userFirstName.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateUserFirstName_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = "J";

            // Act
            var exception = Record.Exception(() => new UserFirstName(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidFirstNameException>();
        }

        [Fact]
        public void CreateUserFirstName_WithNullValue_ShouldThrow()
        {
            // Arrange
            string value = null;

            // Act
            var exception = Record.Exception(() => new UserFirstName(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidFirstNameException>();
        }

        [Fact]
        public void CreateUserFirstName_WithEmptyValue_ShouldThrow()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var exception = Record.Exception(() => new UserFirstName(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidFirstNameException>();
        }
    }
}