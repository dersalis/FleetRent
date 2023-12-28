using FleetRent.Api.Exceptions;

namespace FleetRent.Api.ValueObjects
{
    public sealed record CarModel
    {
        public string Value { get; }

        public CarModel(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidCarModelException();
            }
            
            Value = value;
        }

        public static implicit operator string(CarModel date) => date.Value;
        public static implicit operator CarModel(string value) => new(value);

        public override string ToString() =>  Value;
    }
}