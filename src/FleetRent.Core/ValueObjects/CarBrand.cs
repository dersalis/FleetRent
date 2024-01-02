using FleetRent.Core.Exceptions;

namespace FleetRent.Core.ValueObjects
{
    public sealed record CarBrand
    {
        public string Value { get; }

        public CarBrand(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyBrandException();
            }
            
            Value = value;
        }

        public static implicit operator string(CarBrand date) => date.Value;
        public static implicit operator CarBrand(string value) => new(value);

        public override string ToString() =>  Value;
    }
}