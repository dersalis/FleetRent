using FleetRent.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetRent.Infrastructure.DAL
{
    public sealed class FleetRentDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Hire> Hires { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        public FleetRentDbContext(DbContextOptions<FleetRentDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}