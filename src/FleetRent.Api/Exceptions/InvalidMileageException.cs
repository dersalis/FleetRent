using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the start mileage is greater than the end mileage.
    /// </summary>
    public class InvalidMileageException : BaseException
    {
        public InvalidMileageException() : base("Start mileage cannot be greater than end mileage.")
        {
            
        }
    }
}