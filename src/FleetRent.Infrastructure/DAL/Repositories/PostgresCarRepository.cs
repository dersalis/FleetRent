using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostgresCarRepository : IRepository<Car>
    {
        private readonly FleetRentDbContext _context;

        public PostgresCarRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Car entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<Car> GetAsync(Guid id)
            => _context.Cars.SingleOrDefaultAsync(car => car.Id == (CarId)id);

        public async Task<IEnumerable<Car>> GetAllAsync()
            => await _context.Cars
            .Include(i => i.Hires)
            .Include(i => i.Reservations)
            .ToListAsync();

        public async Task UpdateAsync(Car entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}