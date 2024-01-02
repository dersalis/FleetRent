namespace FleetRent.Core.Exceptions
{
    public class InvalidCarModelException : BaseException
    {
        public InvalidCarModelException() : base($"Invalid car model")
        {
            
        }
    }
}