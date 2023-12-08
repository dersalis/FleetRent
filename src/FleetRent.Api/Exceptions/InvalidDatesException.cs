using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.Exceptions
{
    public class InvalidDatesException : BaseException
    {
        public InvalidDatesException() : base("Start date cannot be greater than end date.")
        {}
    }
}