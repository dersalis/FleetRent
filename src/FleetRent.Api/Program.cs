using FleetRent.Api.Entities;
using FleetRent.Api.Repositories;
using FleetRent.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository<Car>, InMemoryCarRepository>();
builder.Services.AddScoped<IRepository<User>, InMemoryUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
