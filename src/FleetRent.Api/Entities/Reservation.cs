using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Entities
{
    public class Reservation
    {
        public Guid Id { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        
    }
}