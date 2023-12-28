namespace FleetRent.Api.ValueObjects
{
    public sealed record IsActive
    {
        public bool Value { get; }

        public IsActive(bool value)
        {
            Value = value;
        }

        public static implicit operator bool(IsActive isActive) => isActive.Value;
        public static implicit operator IsActive(bool isActive) => new(isActive);
    }
}