namespace FleetRent.Application.Commands.Reservation
{
    public record EndReservation(Guid Id, Guid CarId, DateTime EndDate);
}