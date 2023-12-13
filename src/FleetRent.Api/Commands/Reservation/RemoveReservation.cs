using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Commands.Reservation
{
    public record RemoveReservation(Guid Id, Guid CarId);
}