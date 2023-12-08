using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid email address is encountered.
    /// </summary>
    public class InvalidEmailException : BaseException
    {
        public InvalidEmailException() : base("Invalid email address.")
        {}
    }
}