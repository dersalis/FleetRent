using FleetRent.Api.Entities;
using FleetRent.Api.Dtos;
using FleetRent.Api.Commands.Car;
using FleetRent.Api.Commands.Hire;
using FleetRent.Api.Commands.Reservation;
using FleetRent.Api.ValueObjects;
using FleetRent.Api.Repositories;

namespace FleetRent.Api.Services
{

    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<User> _userRepository;

        public CarService(IRepository<Car> carRepository, IRepository<User> userRepository)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<CarDto> GetAll()
        {
            var cars = _carRepository.GetAll()
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
            bool isRegistrationNumberUnique = _carRepository.GetAll().Any(x => x.RegistrationNumber == command.RegistrationNumber);
            if (isRegistrationNumberUnique)
            {
                return default;
            }

            Guid carId = Guid.NewGuid();
            Car car = new Car(carId, command.Brand, command.Model, command.ProductionYear, command.RegistrationNumber, command.Mileage, command.Color, command.FuelType);
            _carRepository.Add(car);

            return carId;
        }

        public bool Update(UpdateCar command)
        {
            bool isRegistrationNumberUnique = _carRepository.GetAll().Any(x => x.RegistrationNumber == command.RegistrationNumber && x.Id != (CarId)command.Id);
            if (isRegistrationNumberUnique)
            {
                return false;
            }

            Car carToUpdate = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.Id);
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
            Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.Id);
            if (existingCar is null)
            {
                return false;
            }

            existingCar.ChangeActivity(false);

            return true;
        }

        public bool StartHire(StartHire command)
        {
            Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            User existingUser = _userRepository.GetAll().SingleOrDefault(x => x.Id == (UserId)command.UserId);
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
            Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.CarId);
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
            Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.CarId);
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
            Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            User existingUser = _userRepository.GetAll().SingleOrDefault(x => x.Id == (UserId)command.UserId);
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
            Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            Reservation existingReservation = existingCar.Reservations.SingleOrDefault(x => x.Id == (ReservationId)command.Id);
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
            Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.CarId);
            if (existingCar is null)
            {
                return false;
            }

            Reservation existingReservation = existingCar.Reservations.SingleOrDefault(x => x.Id == (ReservationId)command.Id);
            if (existingReservation is null)
            {
                return false;
            }

            existingCar.RemoveReservation(existingReservation);

            return true;
        }
    }
}