using FleetRent.Infrastructure.DAL;
using FleetRent.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ExceptionMidelware>();
            
            // services.AddSingleton<IRepository<Car>, InMemoryCarRepository>();
            // services.AddSingleton<IRepository<User>, InMemoryUserRepository>();
            services.AddPostgres(configuration);

            return services;
        }
        
        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMidelware>();
            return app;
        }
    }
}