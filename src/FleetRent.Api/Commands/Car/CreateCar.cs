using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Enums;

namespace FleetRent.Api.Commands.Car
{
    public record CreateCar(string Brand, string Model, int ProductionYear, string RegistrationNumber, int Mileage, string Color, FuelType FuelType);
}