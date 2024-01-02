namespace FleetRent.Application.Commands.Reservation
{
    public record StartReservation(Guid CarId, DateTime StartDate, Guid UserId);
}