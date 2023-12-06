using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class EmptyEmailException : BaseException
    {
        public EmptyEmailException() : base("Email cannot be empty.")
        { }
    }
}