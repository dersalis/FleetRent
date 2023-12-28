using FleetRent.Api.Exceptions;

namespace FleetRent.Api.ValueObjects
{
    public sealed record CarProductionYear
    {
        public int Value { get; }

        public CarProductionYear(int value)
        {
            if(value < 1900 || value > DateTime.Now.Year)
            {
                throw new InvalidProductionYearException();
            }
            
            Value = value;
        }

        public static implicit operator int(CarProductionYear date) => date.Value;
        public static implicit operator CarProductionYear(int value) => new(value);

        public override string ToString() =>  Value.ToString();
    }
}