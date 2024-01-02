namespace FleetRent.Core.Exceptions
{
    public class EmptyModelException : BaseException
    {
        public EmptyModelException() : base("Model cannot be null, empty, or consist only of whitespace characters.")
        {
            
        }
    }
}