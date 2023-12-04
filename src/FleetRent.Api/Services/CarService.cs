using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FleetRent.Api.Models;
using FleetRent.Api.Enums;

namespace FleetRent.Api.Services
{

    public class CarService
    {
        private static int _id = 0;
    // Utwórz listę samochodów
    private static List<Car> _cars = new List<Car>
    {
        new Car
        {
            Id = ++_id,
            Brand = "Ford",
            Model = "Focus",
            ProductionYear = 2010,
            RegistrationNumber = "KR12345",
            Mileage = 100000,
            Color = "Czerwony",
            FuelType = FuelType.Benzyna
        },
        new Car
        {
            Id = ++_id,
            Brand = "Opel",
            Model = "Astra",
            ProductionYear = 2015,
            RegistrationNumber = "KR54321",
            Mileage = 50000,
            Color = "Czarny",
            FuelType = FuelType.Diesel
        },
        new Car
        {
            Id = ++_id,
            Brand = "Toyota",
            Model = "Yaris",
            ProductionYear = 2018,
            RegistrationNumber = "KR67890",
            Mileage = 10000,
            Color = "Biały",
            FuelType = FuelType.Hybryda
        },
    };

        public async Task<IEnumerable<Car>> GetAllAsync() => _cars;

        public async Task<Car> GetByIdAsync(int id) => _cars.SingleOrDefault(x => x.Id == id);

        public async Task<int?> CreateAsync(Car car)
        {
            bool isRegistrationNumberUnique = _cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);
            if (isRegistrationNumberUnique)
            {
                return default;
            }

            car.Id = ++_id;
            _cars.Add(car);

            return _id;
        }

        public async Task<bool> UpdateAsync(int id, Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == id);
            if (carToUpdate is null)
            {
                return false;
            }

            carToUpdate.Brand = car.Brand;
            carToUpdate.Model = car.Model;
            carToUpdate.ProductionYear = car.ProductionYear;
            carToUpdate.RegistrationNumber = car.RegistrationNumber;
            carToUpdate.Mileage = car.Mileage;
            carToUpdate.Color = car.Color;
            carToUpdate.FuelType = car.FuelType;

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.Id == id);
            if (carToDelete is null)
            {
                return false;
            }

            _cars.Remove(carToDelete);

            return true;
        }
    }
}