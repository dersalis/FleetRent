using Shouldly;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class IsActiveTests
    {
        [Fact]
        public void CreateIsActive_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = true;

            // Act
            var isActive = new IsActive(value);

            // Assert
            isActive.Value.ShouldBe(value);
        }
    }
}