namespace FleetRent.Application.Commands.User
{
    public record UpdateUser(Guid UserId, string FirstName, string LastName, string Email, string Phone);
}