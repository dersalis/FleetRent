using FleetRent.Core.Exceptions;

namespace FleetRent.Core.ValueObjects
{
    public sealed record UserFirstName
    {
        public string Value { get; }

        public UserFirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidFirstNameException(value);
            }

            Value = value;
        }

        public override string ToString() => Value;
        public static implicit operator string(UserFirstName value) => value.Value;
        public static implicit operator UserFirstName(string value) => value is null ? null : new(value);
    }
}