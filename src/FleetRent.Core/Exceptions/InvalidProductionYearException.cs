namespace FleetRent.Core.Exceptions
{
    public class InvalidProductionYearException : BaseException
    {
        public InvalidProductionYearException() : base("Production year must be between 1900 and the current year.")
        {
        }
    }
}