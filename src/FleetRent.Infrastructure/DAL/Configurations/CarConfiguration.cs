using FleetRent.Core.Entities;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FleetRent.Infrastructure.DAL.Configurations
{
    internal sealed class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
            .HasConversion(
                id => id.Value,
                id => new CarId(id));

            builder.Property(c => c.Brand)
                .HasConversion(
                    brand => brand.Value,
                    brand => new CarBrand(brand));
            
            builder.Property(c => c.Model)
                .HasConversion(
                    model => model.Value,
                    model => new CarModel(model));
            
            builder.Property(c => c.ProductionYear)
                .HasConversion(
                    productionYear => productionYear.Value,
                    productionYear => new CarProductionYear(productionYear));
            
            builder.Property(c => c.RegistrationNumber)
                .HasConversion(
                    registrationNumber => registrationNumber.Value,
                    registrationNumber => new CarRegistrationNumber(registrationNumber));

            builder.Property(c => c.Mileage)
                .HasConversion(
                    mileage => mileage.Value,
                    mileage => new CarMileage(mileage));

            builder.Property(c => c.Color)
                .HasConversion(
                    color => color.Value,
                    color => new CarColor(color));

            builder.Property(c => c.IsActive)
                .HasConversion(
                    isActive => isActive.Value,
                    isActive => new IsActive(isActive));
        }
    }
}