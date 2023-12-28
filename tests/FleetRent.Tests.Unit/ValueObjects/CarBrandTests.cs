using Xunit;
using Shouldly;
using FleetRent.Api.ValueObjects;
using FleetRent.Api.Exceptions;

namespace FleetRent.Tests.Unit.ValueObjects
{
    public class CarBrandTests
    {
        [Fact]
        public void CrateCarBrand_WhenBrandIsEmpty_ThrowsEmptyBrandException()
        {
            // Arrange
            var brand = string.Empty;

            // Act
            var exception = Record.Exception(() => new CarBrand(brand));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyBrandException>();
        }

        [Fact]
        public void CrateCarBrand_WhenBrandIsNull_ThrowsEmptyBrandException()
        {
            // Arrange
            string brand = null;

            // Act
            var exception = Record.Exception(() => new CarBrand(brand));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyBrandException>();
        }

        [Fact]
        public void CrateCarBrand_WhenBrandIsWhiteSpace_ThrowsEmptyBrandException()
        {
            // Arrange
            var brand = " ";

            // Act
            var exception = Record.Exception(() => new CarBrand(brand));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<EmptyBrandException>();
        }

        [Fact]
        public void CrateCarBrand_WhenBrandIsValid_ReturnsCarBrand()
        {
            // Arrange
            var brand = "BMW";

            // Act
            var carBrand = new CarBrand(brand);

            // Assert
            carBrand.ShouldNotBeNull();
            carBrand.ShouldBeOfType<CarBrand>();
            carBrand.Value.ShouldBe(brand);
        }
    }
}