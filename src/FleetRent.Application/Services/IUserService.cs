using FleetRent.Application.Commands.User;
using FleetRent.Application.Dtos;

namespace FleetRent.Application.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto GetById(Guid id);
        Guid? Create(CreateUser command);
        bool Update(UpdateUser command);
        bool Deactivate(Guid id);
    }
}