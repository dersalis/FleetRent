using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an email already exists.
    /// </summary>
    public class EmailAlreadyExistException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAlreadyExistException"/> class with a default error message.
        /// </summary>
        public EmailAlreadyExistException() : base("Email already exist")
        {}
    }
}