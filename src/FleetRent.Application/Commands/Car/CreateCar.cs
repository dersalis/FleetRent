using FleetRent.Core.Enums;

namespace FleetRent.Application.Commands.Car
{
    public record CreateCar(string Brand, string Model, int ProductionYear, string RegistrationNumber, int Mileage, string Color, FuelType FuelType);
}