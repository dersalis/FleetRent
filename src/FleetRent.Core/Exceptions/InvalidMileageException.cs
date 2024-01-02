namespace FleetRent.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the start mileage is greater than the end mileage.
    /// </summary>
    public class InvalidMileageException : BaseException
    {
        public InvalidMileageException() : base("Start mileage cannot be greater than end mileage.")
        {
            
        }
    }
}