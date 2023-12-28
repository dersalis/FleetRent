using FleetRent.Api.Exceptions;
using FleetRent.Api.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class PhoneTests
    {
        [Fact]
        public void CreatePhone_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = "+48123456789";

            // Act
            var phone = new Phone(value);

            // Assert
            phone.Value.ShouldBe(value);
        }

        [Fact]
        public void CreatePhone_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = "1234567";

            // Act
            var exception = Record.Exception(() => new Phone(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPhoneException>();
        }

        [Fact]
        public void CreatePhone_WithNullValue_ShouldThrow()
        {
            // Arrange
            string value = null;

            // Act
            var exception = Record.Exception(() => new Phone(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyPhoneException>();
        }

        [Fact]
        public void CreatePhone_WithEmptyValue_ShouldThrow()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var exception = Record.Exception(() => new Phone(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyPhoneException>();
        }

        [Fact]
        public void CreatePhone_WithWhitespaceValue_ShouldThrow()
        {
            // Arrange
            var value = " ";

            // Act
            var exception = Record.Exception(() => new Phone(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyPhoneException>();
        }

        [Fact]
        public void CreatePhone_WithLettersValue_ShouldThrow()
        {
            // Arrange
            var value = "1234567a";

            // Act
            var exception = Record.Exception(() => new Phone(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPhoneException>();
        }

        [Fact]
        public void CreatePhone_WithSpecialCharactersValue_ShouldThrow()
        {
            // Arrange
            var value = "1234567!";

            // Act
            var exception = Record.Exception(() => new Phone(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPhoneException>();
        }

        [Fact]
        public void CreatePhone_WithTooLongValue_ShouldThrow()
        {
            // Arrange
            var value = "12345678901234567890";

            // Act
            var exception = Record.Exception(() => new Phone(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PhoneToLongException>();
        }
    }
}