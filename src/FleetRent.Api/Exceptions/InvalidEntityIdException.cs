namespace FleetRent.Api.Exceptions
{
    public class InvalidEntityIdException : BaseException
    {
        public InvalidEntityIdException(Guid id) : base($"Invalid entity id: {id}")
        {
            
        }
    }
}