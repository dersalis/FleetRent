using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class NullHireException : BaseException
    {
        public NullHireException() : base("Hire cannot be null.")
        {
            
        }
    }
}