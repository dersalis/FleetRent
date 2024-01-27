using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostgresUserRepository : IRepository<User>
    {
        private readonly FleetRentDbContext _context;
        public PostgresUserRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<User> GetAsync(Guid id)
            => _context.Users
                .SingleOrDefaultAsync(user => user.Id == (UserId)id);

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.AsEnumerable();
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}