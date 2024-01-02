using FleetRent.Application.Commands.Car;
using FleetRent.Application.Commands.Hire;
using FleetRent.Application.Commands.Reservation;
using FleetRent.Application.Dtos;

namespace FleetRent.Application.Services
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