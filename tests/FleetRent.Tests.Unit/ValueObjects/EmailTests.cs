using Xunit;
using Shouldly;
using FleetRent.Api.ValueObjects;
using FleetRent.Api.Exceptions;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void CreateEmail_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = "dr@wp.pl";

            // Act
            var email = new Email(value);

            // Assert
            email.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateEmail_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = "dr@wp";

            // Act
            var exception = Record.Exception(() => new Email(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidEmailException>();
        }

        [Fact]
        public void CreateEmail_WithNullValue_ShouldThrow()
        {
            // Arrange
            string value = null;

            // Act
            var exception = Record.Exception(() => new Email(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyEmailException>();
        }

        [Fact]
        public void CreateEmail_WithEmptyValue_ShouldThrow()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var exception = Record.Exception(() => new Email(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyEmailException>();
        }
    }
}