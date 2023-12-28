using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Exceptions;
using FleetRent.Api.ValueObjects;
using Shouldly;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class UserLastNameTests
    {
        [Fact]
        public void CreateUserLastName_WithValidValue_ShouldNotThrow()
        {
            // Arrange
            var value = "LastName";

            // Act
            var userLastName = new UserLastName(value);

            // Assert
            userLastName.Value.ShouldBe(value);
        }

        [Fact]
        public void CreateUserLastName_WithInvalidValue_ShouldThrow()
        {
            // Arrange
            var value = string.Empty;

            // Act
            var exception = Record.Exception(() => new UserLastName(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidLastNameException>();
        }

        [Fact]
        public void CreateUserLastName_WithNullValue_ShouldThrow()
        {
            // Arrange
            string value = null;

            // Act
            var exception = Record.Exception(() => new UserLastName(value));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidLastNameException>();
        }
    }
}