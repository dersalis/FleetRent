using FleetRent.Api.Commands.Car;
using FleetRent.Api.Commands.Hire;
using FleetRent.Api.Commands.Reservation;
using FleetRent.Api.Dtos;

namespace FleetRent.Api.Services
{
    public interface ICarService
    {
        IEnumerable<CarDto> GetAll();
        CarDto GetById(Guid id);
        Guid? Create(CreateCar command);
        bool Update(UpdateCar command);
        bool Deactivate(SetCarInactive command);
        bool StartHire(StartHire command);
        bool EndHire(EndHire command);
        bool RemoveHire(RemoveHire command);
        bool StartReservation(StartReservation command);
        bool EndReservation(EndReservation command);
        bool RemoveReservation(RemoveReservation command);
        
    }
}