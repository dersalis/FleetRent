using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Entities;
using FleetRent.Api.Enums;

namespace FleetRent.Tests.Unit.Entities
{
    public class CarTest
    {
        [Fact]
        public void ChangeBrand_WhenCalled_ChangesBrand()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var newBrand = "BMW";

            // Act
            car.ChangeBrand(newBrand);

            // Assert
            Assert.Equal(newBrand, car.Brand);
        }

        [Fact]
        public void ChangeModel_WhenCalled_ChangesModel()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var newModel = "A6";

            // Act
            car.ChangeModel(newModel);

            // Assert
            Assert.Equal(newModel, car.Model);
        }

        [Fact]
        public void ChangeProductionYear_WhenCalled_ChangesProductionYear()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var newProductionYear = 2011;

            // Act
            car.ChangeProductionYear(newProductionYear);

            // Assert
            Assert.Equal(newProductionYear.ToString(), car.ProductionYear.ToString());
        }

        [Fact]
        public void ChangeRegistrationNumber_WhenCalled_ChangesRegistrationNumber()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var newRegistrationNumber = "XYZ9879";

            // Act
            car.ChangeRegistrationNumber(newRegistrationNumber);

            // Assert
            Assert.Equal(newRegistrationNumber, car.RegistrationNumber);
        }

        [Fact]
        public void ChangeMileage_WhenCalled_ChangesMileage()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var newMileage = 200000;

            // Act
            car.ChangeMileage(newMileage);

            // Assert
            Assert.Equal(newMileage.ToString(), car.Mileage.ToString());
        }

        [Fact]
        public void ChangeColor_WhenCalled_ChangesColor()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var newColor = "White";

            // Act
            car.ChangeColor(newColor);

            // Assert
            Assert.Equal(newColor, car.Color);
        }

        [Fact]
        public void ChangeFuelType_WhenCalled_ChangesFuelType()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var newFuelType = FuelType.BenzynaLPG;

            // Act
            car.ChangeFuelType(newFuelType);

            // Assert
            Assert.Equal(newFuelType, car.FuelType);
        }

        [Fact]
        public void AddHire_WhenCalled_AddsHire()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);
            var user = new User(Guid.NewGuid(), "John", "Doe", "jd@wp.pl", "+48123456789");
            var startDate = new DateTime(2023, 12, 26);
            var endDate = startDate.AddDays(1);
            var hire = new Hire(Guid.NewGuid(), startDate, endDate, user, 100, 200, startDate, endDate);

            // Act
            car.AddHire(hire);

            // Assert
            Assert.Equal(hire, car.Hires.First());
        }

        [Fact]
        public void RemoveHire_WhenCalled_RemovesHire()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black", FuelType.Diesel);

            var user = new User(Guid.NewGuid(), "John", "Doe", "jd@wp.pl", "+48123456789");
            var startDate = new DateTime(2023, 12, 26);
            var endDate = startDate.AddDays(1);
            var hire = new Hire(Guid.NewGuid(), startDate, endDate, user, 100, 200, startDate, endDate);

            car.AddHire(hire);

            // Act
            car.RemoveHire(hire);

            // Assert
            Assert.Empty(car.Hires);
        }

        [Fact]
        public void AddReservation_WhenCalled_AddsReservation()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black",
                FuelType.Diesel);

            var user = new User(Guid.NewGuid(), "John", "Doe", "jd@wp.pl", "+48123456789");
            var startDate = new DateTime(2023, 12, 26);
            var endDate = startDate.AddDays(1);
            var reservation = new Reservation(Guid.NewGuid(), startDate, endDate, user);

            // Act
            car.AddReservation(reservation);

            // Assert
            Assert.Equal(reservation, car.Reservations.First());
        }

        [Fact]
        public void RemoveReservation_WhenCalled_RemovesReservation()
        {
            // Arrange
            var car = new Car(Guid.NewGuid(), "Audi", "A4", 2010, "ABC1234", 100000, "Black",
                FuelType.Diesel);

            var user = new User(Guid.NewGuid(), "John", "Doe", "jd@wp.pl", "+48123456789");
            var startDate = new DateTime(2023, 12, 26);
            var endDate = startDate.AddDays(1);
            var reservation = new Reservation(Guid.NewGuid(), startDate, endDate, user);

            car.AddReservation(reservation);

            // Act
            car.RemoveReservation(reservation);

            // Assert
            Assert.Empty(car.Reservations);
        }
    }
}