using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Core.ValueObjects;

namespace FleetRent.Infrastructure.DAL.Repositories
{
    public class PostrgresReservationRepository : IRepository<Reservation>
    {
        private readonly FleetRentDbContext _context;

        public PostrgresReservationRepository(FleetRentDbContext context)
        {
            _context = context;
        }

        public void Add(Reservation entity)
        {
            _context.Reservations.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            _context.SaveChanges();
        }

        public Reservation Get(Guid id)
            => _context.Reservations.SingleOrDefault(car => car.Id == (ReservationId)id);

        public IEnumerable<Reservation> GetAll()
            => _context.Reservations.ToList();

        public void Update(Reservation entity)
        {
            _context.Reservations.Update(entity);
            _context.SaveChanges();
        }
    }
}