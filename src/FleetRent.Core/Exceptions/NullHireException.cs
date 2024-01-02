namespace FleetRent.Core.Exceptions
{
    public class NullHireException : BaseException
    {
        public NullHireException() : base("Hire cannot be null.")
        {
            
        }
    }
}