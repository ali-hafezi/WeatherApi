
using Microsoft.EntityFrameworkCore;
using WeatherApi.Application.Command.Cities.V1;
using WeatherApi.Domain.Entities.Cities;
using WeatherApi.Persistence.EF;
using WeatherApi.Persistence.EF.Hilo;
using WeatherApi.Persistence.EF.Repositories.Cities;
using WeatherApi.RestApi.Common;


var builder = WebApplication.CreateBuilder(args);





var cnnString = builder.Configuration.GetConnectionString("Cnn");
builder.Services.AddDbContext<WeatherDbContext>(options => options.UseSqlServer(cnnString));

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CityCommandHandler).Assembly);
});

builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IQueryBus, QueryBus>();

builder.Services.AddScoped<IHiloIdGenerator, HiloIdGenerator>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapDefaultControllerRoute();

app.Run();
