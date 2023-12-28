using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class InvalidLastNameException : BaseException
    {
        public InvalidLastNameException(string lastName) : base($"Invalid last name: {lastName}")
        {
            
        }
    }
}