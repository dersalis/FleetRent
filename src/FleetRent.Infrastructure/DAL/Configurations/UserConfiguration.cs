using FleetRent.Core.Entities;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FleetRent.Infrastructure.DAL.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasConversion(
                    id => id.Value,
                    id => new UserId(id));

            builder.Property(u => u.FirstName)
                .HasConversion(
                    firstName => firstName.Value,
                    firstName => new UserFirstName(firstName));

            builder.Property(u => u.LastName)
                .HasConversion(
                    lastName => lastName.Value,
                    lastName => new UserLastName(lastName));

            builder.Property(u => u.Email)
                .HasConversion(
                    email => email.Value,
                    email => new Email(email));

            builder.Property(u => u.IsActive)
                .HasConversion(
                    isActive => isActive.Value,
                    isActive => new IsActive(isActive));
        }
    }
}