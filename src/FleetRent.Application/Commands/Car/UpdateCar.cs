using FleetRent.Core.Enums;

namespace FleetRent.Application.Commands.Car
{
    public record UpdateCar(Guid Id, string Brand, string Model, int ProductionYear, string RegistrationNumber, int Mileage, string Color, FuelType FuelType);
}