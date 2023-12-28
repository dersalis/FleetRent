using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetRent.Api.ValueObjects
{
    public sealed record CarColor
    {
        public string Value { get; }

        public CarColor(string value)
        {            
            Value = value;
        }

        public static implicit operator string(CarColor date) => date.Value;
        public static implicit operator CarColor(string value) => new(value);

        public override string ToString() =>  Value;
        
    }
}