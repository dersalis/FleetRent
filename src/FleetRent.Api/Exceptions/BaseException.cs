using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}