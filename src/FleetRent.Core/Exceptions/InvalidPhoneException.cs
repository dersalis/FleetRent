namespace FleetRent.Core.Exceptions
{
    public class InvalidPhoneException : BaseException
    {
        public InvalidPhoneException(string phone) : base($"Phone number is invalid: {phone}")
        {
            
        }
    }
}