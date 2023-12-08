using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when weekend days are not allowed.
    /// </summary>
    public class WekendDayException : BaseException
    {
        public WekendDayException() : base("Weekend days are not allowed.")
        {}
    }
}