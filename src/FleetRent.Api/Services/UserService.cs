using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Commands.User;
using FleetRent.Api.Dtos;
using FleetRent.Api.Entities;

namespace FleetRent.Api.Services
{
    public class UserService
    {
        private readonly static List<User> _users = new() 
        {
            new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "John", "Doe", "john.doe@wp.pl", "123456789"),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Jane", "Doe", "jane.doe@wp.pl", "987654321"),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000003"), "John", "Smith", "john.smith@wp.pl", "123123123"),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Jane", "Smith", "jane.smith@wp.pl", "321321321"),
        };

        public IEnumerable<UserDto> GetAll()
        {
            var users = _users
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                    Phone = user.Phone,
                    IsActive = user.IsActive
                });

            return users;
        }

        public UserDto GetById(Guid id)
        {
            var user = GetAll().SingleOrDefault(user => user.Id == id);
            
            return user;
        }

        public Guid? Create(CreateUser command)
        {
            var user = new User(Guid.NewGuid(), command.FirstName, command.LastName, command.Email, command.Phone);
            _users.Add(user);

            return user.Id;
        }

        public bool Update(UpdateUser command)
        {
            var existingUser = _users.SingleOrDefault(user => user.Id == command.UserId);
            if (existingUser is null)
            {
                return false;
            }

            existingUser.ChangeFirstName(command.FirstName);
            existingUser.ChangeLastName(command.LastName);
            existingUser.ChangeEmail(command.Email);
            existingUser.ChangePhone(command.Phone);

            return true;
        }

        public bool Deactivate(Guid id)
        {
            var existingUser = _users.SingleOrDefault(user => user.Id == id);
            if (existingUser is null)
            {
                return false;
            }

            existingUser.ChangeActivity(false);

            return true;
        }
    }
}