namespace FleetRent.Core.Exceptions
{
    public class EmptyBrandException : BaseException
    {
        public EmptyBrandException() : base("Brand cannot be null, empty, or consist only of whitespace characters.")
        {   
        }
    }
}