namespace FleetRent.Core.Exceptions
{
    public class InvalidLastNameException : BaseException
    {
        public InvalidLastNameException(string lastName) : base($"Invalid last name: {lastName}")
        {
            
        }
    }
}