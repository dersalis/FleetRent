using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostgresUserRepository : IRepository<User>
    {
        private readonly FleetRentDbContext _context;
        public PostgresUserRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public User Get(Guid id)
            => _context.Users.SingleOrDefault(user => user.Id == (UserId)id);

        public IEnumerable<User> GetAll()
            => _context.Users.ToList();

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}