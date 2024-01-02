namespace FleetRent.Application.Commands.Hire
{
    public record StartHire(Guid CarId, Guid UserId, DateTime StartDate, DateTime EndDate, int StartMileage);
}