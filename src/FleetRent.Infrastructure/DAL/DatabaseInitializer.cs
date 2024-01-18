using FleetRent.Core.Entities;
using FleetRent.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FleetRent.Infrastructure.DAL
{
    internal sealed class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<FleetRentDbContext>();
                dbContext.Database.Migrate();

                CreateUsers(dbContext);
                CrateCars(dbContext);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;


        private void CreateUsers(FleetRentDbContext dbContext)
        {
            var users = dbContext.Users.ToList();

            if(users.Any())
            {
                return;
            }

            users = new () 
            {
                new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "John", "Doe", "john.doe@wp.pl", "+48123456789"),
                new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Jane", "Doe", "jane.doe@wp.pl", "+48987654321"),
                new User(Guid.Parse("00000000-0000-0000-0000-000000000003"), "John", "Smith", "john.smith@wp.pl", "+48123123123"),
                new User(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Jane", "Smith", "jane.smith@wp.pl", "+48321321321"),
            };

            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();
        }

        private void CrateCars(FleetRentDbContext dbContext)
        {
            var cars = dbContext.Cars.ToList();

            if(cars.Any())
            {
                return;
            }

            cars = new ()
            {
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Ford", "Focus", 2010, "KR12345", 100000, "Czerwony", FuelType.Benzyna),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Opel", "Astra", 2015, "KR54321", 50000, "Czarny", FuelType.Diesel),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Fiat", "Punto", 2005, "KR67890", 200000, "Niebieski", FuelType.Benzyna),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Volkswagen", "Golf", 2018, "KR09876", 20000, "Biały", FuelType.Benzyna),
                new Car(Guid.Parse("00000000-0000-0000-0000-000000000005"), "Toyota", "Yaris", 2019, "KR67890", 10000, "Czerwony", FuelType.Hybryda),
            };

            dbContext.Cars.AddRange(cars);
            dbContext.SaveChanges();
        }
    }
}