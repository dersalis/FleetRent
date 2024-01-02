using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IRepository<User>
    {
        private readonly List<User> _users;

        public InMemoryUserRepository()
        {
            _users = new () 
            {
                new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "John", "Doe", "john.doe@wp.pl", "123456789"),
                new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Jane", "Doe", "jane.doe@wp.pl", "987654321"),
                new User(Guid.Parse("00000000-0000-0000-0000-000000000003"), "John", "Smith", "john.smith@wp.pl", "123123123"),
                new User(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Jane", "Smith", "jane.smith@wp.pl", "321321321"),
            };
        }
        
        public void Add(User entity)
            => _users.Add(entity);

        public void Delete(User entity)
            => _users.Remove(entity);

        public User Get(Guid id)
            => _users.SingleOrDefault(user => user.Id == (UserId)id);

        public IEnumerable<User> GetAll()
            => _users;

        public void Update(User entity)
        { }
    }
}