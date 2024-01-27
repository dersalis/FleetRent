using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostgresHireRepository : IRepository<Hire>
    {
        private readonly FleetRentDbContext _context;

        public PostgresHireRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Hire entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Hire entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<Hire> GetAsync(Guid id)
            => _context.Hires
                .SingleOrDefaultAsync(car => car.Id == (HireId)id);

        public async Task<IEnumerable<Hire>> GetAllAsync()
        {
            var hires = await _context.Hires.ToListAsync();

            return hires.AsEnumerable();
        }

        public async Task UpdateAsync(Hire entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}