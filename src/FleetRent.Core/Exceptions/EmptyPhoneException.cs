namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a phone number is empty.
    /// </summary>
    public class EmptyPhoneException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyPhoneException"/> class with a default error message.
        /// </summary>
        public EmptyPhoneException() : base("Phone cannot be empty.")
        { }
    }
}