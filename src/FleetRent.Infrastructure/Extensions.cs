using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Car>, InMemoryCarRepository>();
            services.AddSingleton<IRepository<User>, InMemoryUserRepository>();

            return services;
        }
    }
}