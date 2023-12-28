using FleetRent.Api.Exceptions;

namespace FleetRent.Api.ValueObjects
{
    public sealed record HireDate
    {
        public DateTime Value { get; }

        public HireDate(DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                throw new InvalidHireDateException(value);
            }

            Value = value;
        }

        public HireDate AddDays(int days) => Value.AddDays(days);
        
        public static implicit operator DateTime(HireDate date) => date.Value;
        public static implicit operator HireDate(DateTime value) => new(value);

        public static implicit operator string(HireDate date) => date.Value.ToString("yyyy-MM-dd");
        public static implicit operator HireDate(string value) => new(DateTime.Parse(value));

        public static bool operator >(HireDate date1, HireDate date2) => date1.Value > date2.Value;
        public static bool operator <(HireDate date1, HireDate date2) => date1.Value < date2.Value;
        public static bool operator >=(HireDate date1, HireDate date2) => date1.Value >= date2.Value;
        public static bool operator <=(HireDate date1, HireDate date2) => date1.Value <= date2.Value;
    }
}