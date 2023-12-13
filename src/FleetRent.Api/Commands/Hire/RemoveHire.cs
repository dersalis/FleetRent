using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Commands.Hire
{
    public record RemoveHire(Guid Id, Guid CarId);
}