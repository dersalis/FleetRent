namespace FleetRent.Api.Exceptions
{
    public class PhoneToLongException : BaseException
    {
        public PhoneToLongException(string phone) : base($"Phone number is too long: {phone}")
        {
            
        }
    }
}