using FleetRent.Api.Exceptions;
using FleetRent.Api.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class UserIdTests
    {
        [Fact]
        public void CreateUserId_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = Guid.NewGuid();

            // Act
            var userId = new UserId(value);

            // Assert
            userId.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateUserId_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = Guid.Empty;

            // Act
            var exception = Record.Exception(() => new UserId(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidEntityIdException>();
        }
    }
}