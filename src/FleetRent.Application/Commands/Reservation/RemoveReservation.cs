namespace FleetRent.Application.Commands.Reservation
{
    public record RemoveReservation(
        Guid ReservationId, 
        Guid CarId);
}