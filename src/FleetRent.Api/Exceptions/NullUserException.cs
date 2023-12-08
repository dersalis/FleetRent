using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a user object is null.
    /// </summary>
    public class NullUserException : BaseException
    {
        public NullUserException() : base("User cannot be null.")
        {}
    }
}