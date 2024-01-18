using FleetRent.Core.Entities;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRent.Infrastructure.DAL.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasConversion(
                    id => id.Value,
                    id => new ReservationId(id));

            builder.Property(r => r.UserId)
                .HasConversion(
                    userId => userId.Value,
                    userId => new UserId(userId));
                    
            builder.Property(r => r.StartDate)
                .HasConversion(
                    startDate => startDate.Value,
                    startDate => new ReservationDate(startDate));

            builder.Property(r => r.EndDate)
                .HasConversion(
                    endDate => endDate.Value,
                    endDate => new ReservationDate(endDate));

            builder.Property(r => r.IsActive)
                .HasConversion(
                    isActive => isActive.Value,
                    isActive => new IsActive(isActive));
        }
    }
}