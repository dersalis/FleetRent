using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostrgresReservationRepository : IRepository<Reservation>
    {
        private readonly FleetRentDbContext _context;

        public PostrgresReservationRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reservation entity)
        {
            await _context.Reservations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<Reservation> GetAsync(Guid id)
            => _context.Reservations
                .SingleOrDefaultAsync(car => car.Id == (ReservationId)id);

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            var reservations = await _context.Reservations.ToListAsync();

            return reservations.AsEnumerable();
        }

        public async Task UpdateAsync(Reservation entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}