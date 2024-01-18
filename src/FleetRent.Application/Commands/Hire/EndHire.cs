namespace FleetRent.Application.Commands.Hire
{
    public record EndHire(
        Guid HireId, 
        Guid CarId, 
        int EndMileage, 
        DateTime ReturnDate);
}