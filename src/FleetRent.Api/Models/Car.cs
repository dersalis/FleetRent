using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string RegistrationNumber { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public FuelType FuelType { get; set; }
    }
}