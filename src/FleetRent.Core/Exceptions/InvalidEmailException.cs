namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid email address is encountered.
    /// </summary>
    public class InvalidEmailException : BaseException
    {
        public InvalidEmailException(string email) : base($"Invalid email address: {email}")
        {}
    }
}