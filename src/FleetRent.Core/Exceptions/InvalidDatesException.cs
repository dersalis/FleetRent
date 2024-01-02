namespace FleetRent.Core.Exceptions
{
    public class InvalidDatesException : BaseException
    {
        public InvalidDatesException() : base("Start date cannot be greater than end date.")
        {}
    }
}