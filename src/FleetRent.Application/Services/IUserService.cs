using FleetRent.Application.Commands.User;
using FleetRent.Application.Dtos;

namespace FleetRent.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<Guid?> CreateAsync(CreateUser command);
        Task<bool> UpdateAsync(UpdateUser command);
        Task<bool> DeactivateAsync(Guid id);
    }
}