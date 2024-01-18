using FleetRent.Core.Entities;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRent.Infrastructure.DAL.Configurations
{
    public class HireConfiguration : IEntityTypeConfiguration<Hire>
    {
        public void Configure(EntityTypeBuilder<Hire> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id)
                .HasConversion(
                    id => id.Value,
                    id => new HireId(id));

            builder.Property(h => h.UserId)
                .HasConversion(
                    userId => userId.Value,
                    userId => new UserId(userId));

            builder.Property(h => h.StartDate)
                .HasConversion(
                    startDate => startDate.Value,
                    startDate => new HireDate(startDate));

            builder.Property(h => h.EndDate)
                .HasConversion(
                    endDate => endDate.Value,
                    endDate => new HireDate(endDate))
                    .IsRequired(false);

            builder.Property(h => h.StartMileage)
                .HasConversion(
                    startMileage => startMileage.Value,
                    startMileage => new CarMileage(startMileage));

            builder.Property(h => h.EndMileage)
                .HasConversion(
                    endMileage => endMileage.Value,
                    endMileage => new CarMileage(endMileage))
                    .IsRequired(false);

            builder.Property(h => h.ReleaseDate)
                .HasConversion(
                    releaseDate => releaseDate.Value,
                    releaseDate => new HireDate(releaseDate));

            builder.Property(h => h.ReturnDate)
                .HasConversion(
                    returnDate => returnDate.Value,
                    returnDate => new HireDate(returnDate))
                    .IsRequired(false);

            builder.Property(h => h.IsActive)
                .HasConversion(
                    isActive => isActive.Value,
                    isActive => new IsActive(isActive));
        }
    }
}