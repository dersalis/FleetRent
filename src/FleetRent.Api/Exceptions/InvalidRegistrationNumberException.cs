using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class InvalidRegistrationNumberException : BaseException
    {
        public InvalidRegistrationNumberException(string registrationNumber) : base($"Invalid registration number: {registrationNumber}")
        {
            
        }
    }
}