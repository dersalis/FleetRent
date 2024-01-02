namespace FleetRent.Core.Exceptions
{
    public class InvalidFirstNameException : BaseException
    {
        public InvalidFirstNameException(string firstName) : base($"Invalid first name: {firstName}")
        {
            
        }
    }
}