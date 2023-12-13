using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FleetRent.Api.Entities;
using FleetRent.Api.Enums;
using FleetRent.Api.Dtos;
using FleetRent.Api.Commands.Car;
using FleetRent.Api.Commands.Hire;
using FleetRent.Api.Commands.Reservation;

namespace FleetRent.Api.Services
{

    public class CarService
    {
        private static List<Car> _cars = new ()
        {
            new Car(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Ford", "Focus", 2010, "KR12345", 100000, "Czerwony", FuelType.Benzyna),
            new Car(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Opel", "Astra", 2015, "KR54321", 50000, "Czarny", FuelType.Diesel),
            new Car(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Fiat", "Punto", 2005, "KR67890", 200000, "Niebieski", FuelType.Benzyna),
            new Car(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Volkswagen", "Golf", 2018, "KR09876", 20000, "Biały", FuelType.Benzyna),
            new Car(Guid.Parse("00000000-0000-0000-0000-000000000005"), "Toyota", "Yaris", 2019, "KR67890", 10000, "Czerwony", FuelType.Hybryda),
        };

        private readonly static List<User> _users = new () 
        {
            new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "John", "Doe", "john.doe@wp.pl", "123456789"),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Jane", "Doe", "jane.doe@wp.pl", "987654321"),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000003"), "John", "Smith", "john.smith@wp.pl", "123123123"),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Jane", "Smith", "jane.smith@wp.pl", "321321321"),
        };

        public IEnumerable<CarDto> GetAll()
        {
            var cars = _cars
                .Select(car => new CarDto
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    ProductionYear = car.ProductionYear,
                    RegistrationNumber = car.RegistrationNumber,
                    Mileage = car.Mileage,
                    Color = car.Color,
                    FuelType = car.FuelType,
                    IsActive = car.IsActive,
                    ActiveHires = car.Hires.Count(x => x.IsActive),
                    ActiveReservations = car.Reservations.Count(x => x.IsActive)
                });

            return cars;
        }

        public CarDto GetById(Guid id)
        {
            var car = GetAll().SingleOrDefault(car => car.Id == id);
            
            return car;
        }

        public Guid? Create(CreateCar command)
        {
            bool isRegistrationNumberUnique = _cars.Any(x => x.RegistrationNumber == command.RegistrationNumber);
            if (isRegistrationNumberUnique)
            {
                return default;
            }

            Guid carId = Guid.NewGuid();
            Car car = new Car(carId, command.Brand, command.Model, command.ProductionYear, command.RegistrationNumber, command.Mileage, command.Color, command.FuelType);
            _cars.Add(car);

            return carId;
        }

        public bool Update(UpdateCar command)
        {
            bool isRegistrationNumberUnique = _cars.Any(x => x.RegistrationNumber == command.RegistrationNumber && x.Id != command.Id);
            if (isRegistrationNumberUnique)
            {
                return false;
            }

            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == command.Id);
            if (carToUpdate is null)
            {
                return false;
            }

            carToUpdate.ChangeBrand(command.Brand);
            carToUpdate.ChangeModel(command.Model);
            carToUpdate.ChangeProductionYear(command.ProductionYear);
            carToUpdate.ChangeRegistrationNumber(command.RegistrationNumber);
            carToUpdate.ChangeMileage(command.Mileage);
            carToUpdate.ChangeColor(command.Color);
            carToUpdate.ChangeFuelType(command.FuelType);

            // Zapisz zmiany w bazie danych

            return true;
        }

        public bool Deactivate(SetCarInactive command)
        {
            Car existingCar = _cars.SingleOrDefault(x => x.Id == command.Id);
            if (existingCar is null)
            {
                return false;
            }

            existingCar.ChangeActivity(false);

            return true;
        }

        public bool StartHire(StartHire command)
        {
            Car existingCar = _cars.SingleOrDefault(x => x.Id == command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            User existingUser = _users.SingleOrDefault(x => x.Id == command.UserId);
            if (existingUser is null)
            {
                return false;
            }

            Hire hire = new Hire(Guid.NewGuid(), existingUser, command.StartDate, command.EndDate, command.StartMileage);
            hire.ChangeReleaseDate(command.StartDate);

            existingCar.AddHire(hire);

            return true;
        }

        public bool EndHire(EndHire command)
        {
            Car existingCar = _cars.SingleOrDefault(x => x.Id == command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            Hire existingHire = existingCar.Hires.SingleOrDefault(x => x.Id == command.Id);
            if (existingHire is null)
            {
                return false;
            }

            existingHire.ChangeEndMileage(command.EndMileage);
            existingHire.ChangeReturnDate(command.ReturnDate);

            // Zapisz zmiany w bazie danych

            return true;
        }

        public bool RemoveHire(RemoveHire command)
        {
            Car existingCar = _cars.SingleOrDefault(x => x.Id == command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            Hire existingHire = existingCar.Hires.SingleOrDefault(x => x.Id == command.Id);
            if (existingHire is null)
            {
                return false;
            }

            existingCar.RemoveHire(existingHire);

            return true;
        }

        public bool StartReservation(StartReservation command)
        {
            Car existingCar = _cars.SingleOrDefault(x => x.Id == command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            User existingUser = _users.SingleOrDefault(x => x.Id == command.UserId);
            if (existingUser is null)
            {
                return false;
            }

            Reservation reservation = new Reservation(Guid.NewGuid(), command.StartDate, existingUser);
            existingCar.AddReservation(reservation);

            return true;
        }

        public bool EndReservation(EndReservation command)
        {
            Car existingCar = _cars.SingleOrDefault(x => x.Id == command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            Reservation existingReservation = existingCar.Reservations.SingleOrDefault(x => x.Id == command.Id);
            if (existingReservation is null)
            {
                return false;
            }

            existingReservation.ChangeEndDate(command.EndDate);

            // Zapisz zmiany w bazie danych

            return true;
        }

        public bool RemoveReservation(RemoveReservation command)
        {
            Car existingCar = _cars.SingleOrDefault(x => x.Id == command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            Reservation existingReservation = existingCar.Reservations.SingleOrDefault(x => x.Id == command.Id);
            if (existingReservation is null)
            {
                return false;
            }

            existingCar.RemoveReservation(existingReservation);

            return true;
        }
    }
}