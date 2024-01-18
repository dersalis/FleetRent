using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Infrastructure.DAL
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services)
        {
            const string connectionString = "Host=localhost;Database=FleetRent;Username=postgres;Password=";
            services.AddDbContext<FleetRentDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IRepository<Car>, PostgresCarRepository>();
            services.AddScoped<IRepository<User>, PostgresUserRepository>();
            services.AddHostedService<DatabaseInitializer>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}