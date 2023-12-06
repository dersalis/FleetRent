using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class EmptyPhoneException : BaseException
    {
        public EmptyPhoneException() : base("Phone cannot be empty.")
        { }
    }
}