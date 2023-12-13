using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Commands.Reservation
{
    public record StartReservation(Guid CarId, DateTime StartDate, Guid UserId);
}