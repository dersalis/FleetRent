using FleetRent.Api.Exceptions;

namespace FleetRent.Api.ValueObjects
{
    public sealed record ReservationDate
    {
        public DateTime Value { get; }

        public ReservationDate(DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                throw new InvalidReservationDateException(value);
            }

            Value = value;
        }

        public static implicit operator DateTime(ReservationDate date) => date.Value;
        public static implicit operator ReservationDate(DateTime value) => new(value);

        public static bool operator >(ReservationDate left, ReservationDate right) => left.Value > right.Value;
        public static bool operator <(ReservationDate left, ReservationDate right) => left.Value < right.Value;
        public static bool operator >=(ReservationDate left, ReservationDate right) => left.Value >= right.Value;
        public static bool operator <=(ReservationDate left, ReservationDate right) => left.Value <= right.Value;
    }
}