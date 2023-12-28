using FleetRent.Api.Exceptions;

namespace FleetRent.Api.ValueObjects
{
    public sealed record CarId
    {
        public Guid Value { get; }

        public CarId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static implicit operator Guid(CarId date) => date.Value;
        
        public static implicit operator CarId(Guid value) => new(value);
    }
}