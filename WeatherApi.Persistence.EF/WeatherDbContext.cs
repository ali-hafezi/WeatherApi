
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Entities.City;
using WeatherApi.Domain.Entities.WeatherReport;
using WeatherApi.Domain.ValueObjects;

namespace WeatherApi.Persistence.EF;

public class WeatherDbContext :DbContext
{
    DbSet<City> Cities { get; set; }
    DbSet<WeatherReport> WeatherReports { get; set; }
    public WeatherDbContext(DbContextOptions options) : base(options)
    {
    }

}