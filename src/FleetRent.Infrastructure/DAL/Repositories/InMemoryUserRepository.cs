using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Infrastructure.DAL.Repositories
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
        
        public Task AddAsync(User entity)
        {
            _users.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(User entity)
        {
            _users.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<User> GetAsync(Guid id)
            => Task.FromResult(_users.SingleOrDefault(user => user.Id == (UserId)id));

        public Task<IEnumerable<User>> GetAllAsync()
            => Task.FromResult(_users.AsEnumerable());

        public Task UpdateAsync(User entity)
            => Task.CompletedTask;
    }
}