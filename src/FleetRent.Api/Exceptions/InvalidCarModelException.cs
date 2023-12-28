namespace FleetRent.Api.Exceptions
{
    public class InvalidCarModelException : BaseException
    {
        public InvalidCarModelException() : base($"Invalid car model")
        {
            
        }
    }
}