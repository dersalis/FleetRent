using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class CarNotAvailableException : BaseException
    {
        public CarNotAvailableException() : base("The car is not available for the selected period.")
        {
            
        }
    }
}