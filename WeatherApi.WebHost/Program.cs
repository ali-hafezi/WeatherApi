using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Application.Command.City;
using WeatherApi.Persistence.EF;
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


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapDefaultControllerRoute();

app.Run();
