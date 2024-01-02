namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a user object is null.
    /// </summary>
    public class NullUserException : BaseException
    {
        public NullUserException() : base("User cannot be null.")
        {}
    }
}