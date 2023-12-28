namespace FleetRent.Api.Exceptions
{
    public class InvalidReservationDateException : BaseException
    {
        public InvalidReservationDateException(DateTime date) : base($"The date {date} is invalid.")
        {
            
        }
    }
}