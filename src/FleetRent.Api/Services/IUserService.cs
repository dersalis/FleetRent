using FleetRent.Api.Commands.User;
using FleetRent.Api.Dtos;

namespace FleetRent.Api.Services
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