using FleetRent.Core.Entities;
using FleetRent.Core.Repositories;
using FleetRent.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRent.Infrastructure.DAL
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = configuration.GetOptions<DataBaseOptions>("ConnectionStrings");

            // const string connectionString = "Host=localhost;Database=FleetRent;Username=postgres;Password=";
            services.AddDbContext<FleetRentDbContext>(options => options.UseNpgsql(dbOptions.PostgresConnection));

            services.AddScoped<IRepository<Car>, PostgresCarRepository>();
            services.AddScoped<IRepository<User>, PostgresUserRepository>();
            services.AddScoped<IRepository<Hire>, PostgresHireRepository>();
            services.AddScoped<IRepository<Reservation>, PostrgresReservationRepository>();
            services.AddHostedService<DatabaseInitializer>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName)
        where T : class, new()
        {
            var options = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}