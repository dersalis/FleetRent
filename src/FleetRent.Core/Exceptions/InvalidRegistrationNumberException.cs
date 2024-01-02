namespace FleetRent.Core.Exceptions
{
    public class InvalidRegistrationNumberException : BaseException
    {
        public InvalidRegistrationNumberException(string registrationNumber) : base($"Invalid registration number: {registrationNumber}")
        {
            
        }
    }
}