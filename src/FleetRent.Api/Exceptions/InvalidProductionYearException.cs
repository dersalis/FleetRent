using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class InvalidProductionYearException : BaseException
    {
        public InvalidProductionYearException() : base("Production year must be between 1900 and the current year.")
        {
        }
    }
}