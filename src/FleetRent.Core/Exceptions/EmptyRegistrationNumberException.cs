namespace FleetRent.Core.Exceptions
{
    public class EmptyRegistrationNumberException : BaseException
    {
        public EmptyRegistrationNumberException() : base("Registration number cannot be null, empty, or consist only of whitespace characters.")
        {
            
        }
    }
}