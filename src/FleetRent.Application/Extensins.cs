using FleetRent.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Application
{
    public static class Extensins
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            
            return services;
        }
    }
}