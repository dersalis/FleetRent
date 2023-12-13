using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class EmptyBrandException : BaseException
    {
        public EmptyBrandException() : base("Brand cannot be null, empty, or consist only of whitespace characters.")
        {   
        }
    }
}