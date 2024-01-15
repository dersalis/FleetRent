using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostgresCarRepository : IRepository<Car>
    {
        private readonly FleetRentDbContext _context;

        public PostgresCarRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public void Add(Car entity)
        {
            _context.Cars.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Car entity)
        {
            _context.Cars.Remove(entity);
            _context.SaveChanges();
        }

        public Car Get(Guid id)
            => _context.Cars.SingleOrDefault(car => car.Id == (CarId)id);

        public IEnumerable<Car> GetAll()
            => _context.Cars.ToList();

        public void Update(Car entity)
        {
            _context.Cars.Update(entity);
            _context.SaveChanges();
        }
    }
}