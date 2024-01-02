namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an email already exists.
    /// </summary>
    public class EmailAlreadyExistException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAlreadyExistException"/> class with a default error message.
        /// </summary>
        public EmailAlreadyExistException() : base("Email already exist")
        {}
    }
}