using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Commands.Car
{
    public record SetCarInactive(Guid Id);
}