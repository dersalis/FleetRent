using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class EmptyModelException : BaseException
    {
        public EmptyModelException() : base("Model cannot be null, empty, or consist only of whitespace characters.")
        {
            
        }
    }
}