namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an email is empty.
    /// </summary>
    public class EmptyEmailException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyEmailException"/> class with a default error message.
        /// </summary>
        public EmptyEmailException() : base("Email cannot be empty.")
        { }
    }
}