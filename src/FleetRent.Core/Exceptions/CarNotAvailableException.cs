namespace FleetRent.Core.Exceptions
{
    public class CarNotAvailableException : BaseException
    {
        public CarNotAvailableException() : base("The car is not available for the selected period.")
        {
            
        }
    }
}