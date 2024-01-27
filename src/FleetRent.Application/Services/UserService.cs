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

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new UserDto
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                    Phone = user.Phone,
                    IsActive = user.IsActive
                });
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await GetAllAsync();
            
            return user.SingleOrDefault(user => user.Id == id);
        }

        public async Task<Guid?> CreateAsync(CreateUser command)
        {
            var emailExist = (await _userRepository.GetAllAsync())
                .Any(user => user.Email == command.Email);

            if (emailExist)
            {
                return default;
            }

            var user = new User(Guid.NewGuid(), command.FirstName, command.LastName, command.Email, command.Phone);
            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public async Task<bool> UpdateAsync(UpdateUser command)
        {
            var emailExist = (await _userRepository.GetAllAsync())
                .Any(user => user.Email == command.Email && user.Id != (UserId)command.UserId);

            if (emailExist)
            {
                return false;
            }
            
            var existingUser = (await _userRepository.GetAllAsync())
                .SingleOrDefault(user => user.Id == (UserId)command.UserId);
            
            if (existingUser is null)
            {
                return false;
            }

            existingUser.ChangeFirstName(command.FirstName);
            existingUser.ChangeLastName(command.LastName);
            existingUser.ChangeEmail(command.Email);
            existingUser.ChangePhone(command.Phone);

            await _userRepository.UpdateAsync(existingUser);

            return true;
        }

        public async Task<bool> DeactivateAsync(Guid id)
        {
            var existingUser = (await _userRepository.GetAllAsync())
                .SingleOrDefault(user => user.Id == (UserId)id);

            if (existingUser is null)
            {
                return false;
            }

            existingUser.ChangeActivity(false);

            await _userRepository.UpdateAsync(existingUser);

            return true;
        }
    }
}