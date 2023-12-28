using System.Text.RegularExpressions;
using FleetRent.Api.Exceptions;

namespace FleetRent.Api.ValueObjects
{
    public sealed record CarRegistrationNumber
    {
        private static readonly Regex Regex = new(
        @"^[A-Z]{2,4}\d{4,5}$",
        RegexOptions.Compiled);

        public string Value { get; }

        public CarRegistrationNumber(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyRegistrationNumberException();
            }
            
            value = value.ToUpperInvariant();
            if (!Regex.IsMatch(value))
            {
                throw new InvalidRegistrationNumberException(value);
            }

            Value = value;
        }

        public static implicit operator string(CarRegistrationNumber date) => date.Value;
        public static implicit operator CarRegistrationNumber(string value) => new(value);

        public override string ToString() =>  Value;
        
    }
}