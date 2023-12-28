using FleetRent.Api.Exceptions;
using FleetRent.Api.Enums;
using FleetRent.Api.ValueObjects;

namespace FleetRent.Api.Entities
{
    public class Car
    {
        public CarId Id { get; }
        public CarBrand Brand { get; private set; }
        public CarModel Model { get; private set; }
        public CarProductionYear ProductionYear { get; private set; }
        public CarRegistrationNumber RegistrationNumber { get; private set; }
        public CarMileage Mileage { get; private set; }
        public CarColor Color { get; private set; }
        public FuelType FuelType { get; private set; }
        public IsActive IsActive { get; private set; }
        public IEnumerable<Hire> Hires => _hires;
        public IEnumerable<Reservation> Reservations => _reservations;


        private readonly HashSet<Hire> _hires = new ();
        private readonly HashSet<Reservation> _reservations = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the car.</param>
        /// <param name="brand">The brand of the car.</param>
        /// <param name="model">The model of the car.</param>
        /// <param name="productionYear">The production year of the car.</param>
        /// <param name="registrationNumber">The registration number of the car.</param>
        /// <param name="mileage">The mileage of the car.</param>
        /// <param name="color">The color of the car.</param>
        /// <param name="fuelType">The fuel type of the car.</param>
        public Car(Guid id, string brand, string model, int productionYear, string registrationNumber, int mileage, string color, FuelType fuelType)
        {
            Id = id;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            RegistrationNumber = registrationNumber;
            Mileage = mileage;
            Color = color;
            FuelType = fuelType;
        }

        /// <summary>
        /// Changes the brand of the car.
        /// </summary>
        /// <param name="brand">The new brand of the car.</param>
        public void ChangeBrand(string brand)
        {
            Brand = brand;
        }

        /// <summary>
        /// Changes the model of the car.
        /// </summary>
        /// <param name="model">The new model of the car.</param>
        public void ChangeModel(string model)
        {
            Model = model;
        }

        /// <summary>
        /// Changes the production year of the car.
        /// </summary>
        /// <param name="productionYear">The new production year.</param>
        /// <exception cref="InvalidProductionYearException">Thrown when the production year is invalid.</exception>
        public void ChangeProductionYear(int productionYear)
        {
            ProductionYear = productionYear;
        }

        /// <summary>
        /// Changes the registration number of the car.
        /// </summary>
        /// <param name="registrationNumber">The new registration number.</param>
        public void ChangeRegistrationNumber(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }

        /// <summary>
        /// Changes the mileage of the car.
        /// </summary>
        /// <param name="mileage">The new mileage value.</param>
        /// <exception cref="InvalidMileageException">Thrown when the provided mileage is negative.</exception>
        public void ChangeMileage(int mileage)
        {
            Mileage = mileage;
        }

        /// <summary>
        /// Changes the color of the car.
        /// </summary>
        /// <param name="color">The new color of the car.</param>
        public void ChangeColor(string color)
        {
            Color = color;
        }

        /// <summary>
        /// Changes the fuel type of the car.
        /// </summary>
        /// <param name="fuelType">The new fuel type.</param>
        public void ChangeFuelType(FuelType fuelType)
        {
            FuelType = fuelType;
        }

        /// <summary>
        /// Changes the activity status of the car.
        /// </summary>
        /// <param name="isActive">The new activity status of the car.</param>
        public void ChangeActivity(bool isActive)
        {
            IsActive = isActive;
        }

        /// <summary>
        /// Adds a hire to the car's list of hires.
        /// </summary>
        /// <param name="hire">The hire to be added.</param>
        /// <exception cref="NullHireException">Thrown when the hire is null.</exception>
        public void AddHire(Hire hire)
        {
            if (hire is null)
            {
                throw new NullHireException();
            }

            CheckCarIsAvailable(hire.StartDate, hire.EndDate);

            _hires.Add(hire);
        }

        /// <summary>
        /// Removes a hire from the car's list of hires.
        /// </summary>
        /// <param name="hire">The hire to be removed.</param>
        public void RemoveHire(Hire hire)
        {
            if(hire is null)
            {
                throw new NullHireException();
            }

            _hires.Remove(hire);
        }

        /// <summary>
        /// Adds a reservation to the car.
        /// </summary>
        /// <param name="reservation">The reservation to be added.</param>
        /// <exception cref="NullReservationException">Thrown when the reservation is null.</exception>
        public void AddReservation(Reservation reservation)
        {
            if (reservation is null)
            {
                throw new NullReservationException();
            }

            CheckCarIsAvailable(reservation.StartDate, reservation.EndDate);

            _reservations.Add(reservation);
        }

        /// <summary>
        /// Removes a reservation from the car.
        /// </summary>
        /// <param name="reservation">The reservation to be removed.</param>
        public void RemoveReservation(Reservation reservation)
        {
            if(reservation is null)
            {
                throw new NullReservationException();
            }

            _reservations.Remove(reservation);
        }

        /// <summary>
        /// Checks if the car is available for hire or reservation within the specified date range.
        /// Throws a CarNotAvailableException if the car is already hired or reserved during that time.
        /// </summary>
        /// <param name="startDate">The start date of the requested hire or reservation.</param>
        /// <param name="endDate">The end date of the requested hire or reservation.</param>
        private void CheckCarIsAvailable(DateTime startDate, DateTime endDate)
        {
            if (_hires.Any(existingHire => existingHire.StartDate <= endDate && existingHire.EndDate >= startDate))
            {
                throw new CarNotAvailableException();
            }

            if (_reservations.Any(existingHire => existingHire.StartDate <= (ReservationDate)endDate && existingHire.EndDate >= (ReservationDate)startDate))
            {
                throw new CarNotAvailableException();
            }
        }
    }
}