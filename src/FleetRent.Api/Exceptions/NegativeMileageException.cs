using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the mileage value is negative.
    /// </summary>
    public class NegativeMileageException : BaseException
    {
        public NegativeMileageException() : base("Mileage cannot be negative.")
        {}
    }
}