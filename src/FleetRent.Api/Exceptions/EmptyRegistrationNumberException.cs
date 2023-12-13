using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class EmptyRegistrationNumberException : BaseException
    {
        public EmptyRegistrationNumberException() : base("Registration number cannot be null, empty, or consist only of whitespace characters.")
        {
            
        }
    }
}