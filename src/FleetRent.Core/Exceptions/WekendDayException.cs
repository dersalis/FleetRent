namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when weekend days are not allowed.
    /// </summary>
    public class WekendDayException : BaseException
    {
        public WekendDayException() : base("Weekend days are not allowed.")
        {}
    }
}