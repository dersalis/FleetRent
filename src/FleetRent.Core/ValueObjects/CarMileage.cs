using FleetRent.Core.Exceptions;

namespace FleetRent.Core.ValueObjects
{
    public sealed record CarMileage
    {
        public int Value { get; }

        public CarMileage(int value)
        {
            if(value < 0)
            {
                throw new InvalidMileageException();
            }
            
            Value = value;
        }

        public static implicit operator int(CarMileage date) => date.Value;
        public static implicit operator CarMileage(int value) => new(value);

        public override string ToString() =>  Value.ToString();
        
    }
}