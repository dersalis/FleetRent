using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // services.AddSingleton<IWeeklyParkingSpotRepository, InMemoryWeeklyParkingSpotRepository>();

            return services;
        }
    }
}