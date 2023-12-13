using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Commands.Hire
{
    public record StartHire(Guid CarId, Guid UserId, DateTime StartDate, DateTime EndDate, int StartMileage);
}