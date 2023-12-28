using FleetRent.Api.Exceptions;

namespace FleetRent.Api.ValueObjects
{
    public sealed record UserLastName
    {
        public string Value { get; }

        public UserLastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidLastNameException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(UserLastName value) => value.Value;
        public static implicit operator UserLastName(string value) => value is null ? null : new(value);
    }
}