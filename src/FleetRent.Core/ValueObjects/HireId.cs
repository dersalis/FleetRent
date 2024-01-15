using FleetRent.Core.Exceptions;

namespace FleetRent.Core.ValueObjects
{
    public sealed record HireId
    {
        public Guid Value { get; }

        public HireId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static implicit operator Guid(HireId date) => date.Value;

        public static implicit operator HireId(Guid value) => new(value);
    }
}