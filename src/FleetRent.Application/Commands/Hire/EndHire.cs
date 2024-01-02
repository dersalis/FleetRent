namespace FleetRent.Application.Commands.Hire
{
    public record EndHire(Guid Id, Guid CarId, int EndMileage, DateTime ReturnDate);
}