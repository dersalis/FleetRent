using FleetRent.Application.Commands.User;
using FleetRent.Application.Dtos;
using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetAll()
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
            var emailExist = _userRepository.GetAll().Any(user => user.Email == command.Email);
            if (emailExist)
            {
                return default;
            }

            var user = new User(Guid.NewGuid(), command.FirstName, command.LastName, command.Email, command.Phone);
            _userRepository.Add(user);

            return user.Id;
        }

        public bool Update(UpdateUser command)
        {
            var emailExist = _userRepository.GetAll().Any(user => user.Email == command.Email && user.Id != (UserId)command.UserId);
            if (emailExist)
            {
                return false;
            }
            
            var existingUser = _userRepository.GetAll().SingleOrDefault(user => user.Id == (UserId)command.UserId);
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
            var existingUser = _userRepository.GetAll().SingleOrDefault(user => user.Id == (UserId)id);
            if (existingUser is null)
            {
                return false;
            }

            existingUser.ChangeActivity(false);

            return true;
        }
    }
}