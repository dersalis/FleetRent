using FleetRent.Application.Commands.Car;
using FleetRent.Application.Commands.Hire;
using FleetRent.Application.Commands.Reservation;
using FleetRent.Application.Dtos;
using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Application.Services
{

    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Hire> _hireRepository;
        private readonly IRepository<Reservation> _reservationRepository;

        public CarService(
            IRepository<Car> carRepository, 
            IRepository<User> userRepository,
            IRepository<Hire> hireRepository,
            IRepository<Reservation> reservationRepository)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
            _hireRepository = hireRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            var cars = (await _carRepository.GetAllAsync())
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

        public async Task<CarDto> GetByIdAsync(Guid id)
        {
            var car = (await GetAllAsync()).SingleOrDefault(car => car.Id == id);
            
            return car;
        }

        public async Task<Guid?> CreateAsync(CreateCar command)
        {
            bool isRegistrationNumberUnique = (await _carRepository.GetAllAsync())
                .Any(x => x.RegistrationNumber == command.RegistrationNumber);

            if (isRegistrationNumberUnique)
            {
                return default;
            }

            Guid carId = Guid.NewGuid();
            Car car = new Car(carId, command.Brand, command.Model, command.ProductionYear, command.RegistrationNumber, command.Mileage, command.Color, command.FuelType);
            await _carRepository.AddAsync(car);

            return carId;
        }

        public async Task<bool> UpdateAsync(UpdateCar command)
        {
            bool isRegistrationNumberUnique = (await _carRepository.GetAllAsync())
                .Any(x => x.RegistrationNumber == command.RegistrationNumber && x.Id != (CarId)command.Id);
            
            if (isRegistrationNumberUnique)
            {
                return false;
            }

            Car carToUpdate = (await _carRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (CarId)command.Id);

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

            await _carRepository.UpdateAsync(carToUpdate);

            return true;
        }

        public async Task<bool> DeactivateAsync(SetCarInactive command)
        {
            Car existingCar = (await _carRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (CarId)command.Id);

            if (existingCar is null)
            {
                return false;
            }

            existingCar.ChangeActivity(false);

            await _carRepository.UpdateAsync(existingCar);

            return true;
        }

        public async Task<bool> StartHireAsync(StartHire command)
        {
            Car existingCar = (await _carRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (CarId)command.CarId);

            if (existingCar is null)
            {
                return false;
            }

            User existingUser = (await _userRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (UserId)command.UserId);
            if (existingUser is null)
            {
                return false;
            }

            Hire hire = new Hire(Guid.NewGuid(), existingUser.Id, command.StartDate, command.EndDate, command.StartMileage);
            hire.ChangeReleaseDate(command.StartDate);

            existingCar.AddHire(hire);

            await _carRepository.UpdateAsync(existingCar);

            return true;
        }

        public async Task<bool> EndHireAsync(EndHire command)
        {
            Car existingCar = (await _carRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (CarId)command.CarId);

            if (existingCar is null)
            {
                return false;
            }

            Hire existingHire = existingCar.Hires.SingleOrDefault(x => x.Id == (HireId)command.HireId);
            if (existingHire is null)
            {
                return false;
            }

            existingHire.ChangeEndMileage(command.EndMileage);
            existingHire.ChangeReturnDate(command.ReturnDate);

            await _carRepository.UpdateAsync(existingCar);

            return true;
        }

        public async Task<bool> RemoveHireAsync(RemoveHire command)
        {
            Car existingCar = (await _carRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (CarId)command.CarId);

            if (existingCar is null)
            {
                return false;
            }

            Hire existingHire = existingCar.Hires.SingleOrDefault(x => x.Id == (HireId)command.HireId);
            if (existingHire is null)
            {
                return false;
            }

            existingCar.RemoveHire(existingHire);
            existingHire.ChangeActivity(false);

            await _carRepository.UpdateAsync(existingCar);

            return true;
        }

        public async Task<bool> StartReservationAsync(StartReservation command)
        {
            Car existingCar = (await _carRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (CarId)command.CarId);

            if (existingCar is null)
            {
                return false;
            }

            User existingUser = (await _userRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (UserId)command.UserId);

            if (existingUser is null)
            {
                return false;
            }

            Reservation reservation = new Reservation(Guid.NewGuid(), command.StartDate, command.EndDate, existingUser.Id);
            existingCar.AddReservation(reservation);

            await _carRepository.UpdateAsync(existingCar);

            return true;
        }

        // public bool EndReservation(EndReservation command)
        // {
        //     Car existingCar = _carRepository.GetAll().SingleOrDefault(x => x.Id == (CarId)command.CarId);
        //     if (existingCar is null)
        //     {
        //         return false;
        //     }

        //     Reservation existingReservation = existingCar.Reservations.SingleOrDefault(x => x.Id == (ReservationId)command.Id);
        //     if (existingReservation is null)
        //     {
        //         return false;
        //     }

        //     existingReservation.ChangeEndDate(command.EndDate);

        //     // Zapisz zmiany w bazie danych

        //     return true;
        // }

        public async Task<bool> RemoveReservationAsync(RemoveReservation command)
        {
            Car existingCar = (await _carRepository.GetAllAsync())
                .SingleOrDefault(x => x.Id == (CarId)command.CarId);

            if (existingCar is null)
            {
                return false;
            }

            Reservation existingReservation = existingCar.Reservations.SingleOrDefault(x => x.Id == (ReservationId)command.ReservationId);
            if (existingReservation is null)
            {
                return false;
            }

            existingCar.RemoveReservation(existingReservation);
            existingReservation.ChangeActivity(false);

            await _carRepository.UpdateAsync(existingCar);

            return true;
        }
    }
}