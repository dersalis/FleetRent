using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostgresHireRepository : IRepository<Hire>
    {
        private readonly FleetRentDbContext _context;

        public PostgresHireRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public void Add(Hire entity)
        {
            _context.Hires.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Hire entity)
        {
            _context.Hires.Remove(entity);
            _context.SaveChanges();
        }

        public Hire Get(Guid id)
            => _context.Hires.SingleOrDefault(car => car.Id == (HireId)id);

        public IEnumerable<Hire> GetAll()
            => _context.Hires.ToList();

        public void Update(Hire entity)
        {
            _context.Hires.Update(entity);
            _context.SaveChanges();
        }
    }
}