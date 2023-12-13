using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Commands.Reservation
{
    public record EndReservation(Guid Id, Guid CarId, DateTime EndDate);
}