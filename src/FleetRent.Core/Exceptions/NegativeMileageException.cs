namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the mileage value is negative.
    /// </summary>
    public class NegativeMileageException : BaseException
    {
        public NegativeMileageException() : base("Mileage cannot be negative.")
        {}
    }
}