namespace FleetRent.Core.Exceptions
{
    public class InvalidHireDateException : BaseException
    {
        public InvalidHireDateException(DateTime value) : base($"Invalid hire date: {value}")
        {
            
        }
    }
}