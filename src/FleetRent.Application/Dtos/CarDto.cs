using FleetRent.Core.Enums;

namespace FleetRent.Application.Dtos
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string RegistrationNumber { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public FuelType FuelType { get; set; }
        public bool IsActive { get; set; }
        public int ActiveHires { get; set; }
        public int ActiveReservations { get; set; }
    }
}