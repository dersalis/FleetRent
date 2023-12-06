using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class EmailAlreadyExistException : BaseException
    {
        public EmailAlreadyExistException() : base("Email already exist")
        {}
    }
}