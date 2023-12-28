namespace FleetRent.Api.Exceptions
{
    public class InvalidFirstNameException : BaseException
    {
        public InvalidFirstNameException(string firstName) : base($"Invalid first name: {firstName}")
        {
            
        }
    }
}