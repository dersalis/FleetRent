using FleetRent.Core.Entities;
using FleetRent.Core.Enums;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class InMemoryCarRepository : IRepository<Car>
    {
        private readonly List<Car> _cars;

        public InMemoryCarRepository()
        {
            _cars = new ()
            {
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Ford", "Focus", 2010, "KR12345", 100000, "Czerwony", FuelType.Benzyna),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Opel", "Astra", 2015, "KR54321", 50000, "Czarny", FuelType.Diesel),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Fiat", "Punto", 2005, "KR67890", 200000, "Niebieski", FuelType.Benzyna),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Volkswagen", "Golf", 2018, "KR09876", 20000, "Biały", FuelType.Benzyna),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000005"), "Toyota", "Yaris", 2019, "KR67890", 10000, "Czerwony", FuelType.Hybryda),
            };
        }

        public void Add(Car entity)
            => _cars.Add(entity);

        public void Delete(Car entity)
            => _cars.Remove(entity);

        public Car Get(Guid id)
            => _cars.SingleOrDefault(car => car.Id == (CarId)id);

        public IEnumerable<Car> GetAll()
            => _cars;

        public void Update(Car entity)
        {}
    }
}