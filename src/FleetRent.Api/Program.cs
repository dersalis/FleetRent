using FleetRent.Core;
using FleetRent.Infrastructure;
using FleetRent.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseInfrastructure();

app.MapControllers();

app.Run();
