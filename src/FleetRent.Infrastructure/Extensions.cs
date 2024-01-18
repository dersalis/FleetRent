using FleetRent.Infrastructure.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // services.AddSingleton<IRepository<Car>, InMemoryCarRepository>();
            // services.AddSingleton<IRepository<User>, InMemoryUserRepository>();
            services.AddPostgres();

            return services;
        }
    }
}