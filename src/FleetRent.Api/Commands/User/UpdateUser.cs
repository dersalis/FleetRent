using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Commands.User
{
    public record UpdateUser(Guid UserId, string FirstName, string LastName, string Email, string Phone);
}