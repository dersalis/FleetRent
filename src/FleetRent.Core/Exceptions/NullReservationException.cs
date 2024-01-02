namespace FleetRent.Core.Exceptions
{
    public class NullReservationException : BaseException
    {
        public NullReservationException() : base("Reservation cannot be null.")
        {
            
        }
    }
}