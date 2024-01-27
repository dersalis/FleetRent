using FleetRent.Application.Commands.Car;
using FleetRent.Application.Commands.Hire;
using FleetRent.Application.Commands.Reservation;
using FleetRent.Application.Dtos;

namespace FleetRent.Application.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllAsync();
        Task<CarDto> GetByIdAsync(Guid id);
        Task<Guid?> CreateAsync(CreateCar command);
        Task<bool> UpdateAsync(UpdateCar command);
        Task<bool> DeactivateAsync(SetCarInactive command);
        Task<bool> StartHireAsync(StartHire command);
        Task<bool> EndHireAsync(EndHire command);
        Task<bool> RemoveHireAsync(RemoveHire command);
        Task<bool> StartReservationAsync(StartReservation command);
        // Task<bool> EndReservationAsync(EndReservation command);
        Task<bool> RemoveReservationAsync(RemoveReservation command);
    }
}