using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    /// <summary>
        /// Represents a base exception class.
        /// </summary>
        public class BaseException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BaseException"/> class with a specified error message.
            /// </summary>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            public BaseException(string message) : base(message)
            {
            }
        }
}