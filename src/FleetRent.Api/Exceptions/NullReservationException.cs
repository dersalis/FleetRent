using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class NullReservationException : BaseException
    {
        public NullReservationException() : base("Reservation cannot be null.")
        {
            
        }
    }
}