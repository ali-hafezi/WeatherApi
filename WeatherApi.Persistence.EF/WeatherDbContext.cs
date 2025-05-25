
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Entities.Cities;
using WeatherApi.Domain.Entities.WeatherReport;

namespace WeatherApi.Persistence.EF;

public class WeatherDbContext :DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<WeatherReport> WeatherReports { get; set; }
    public WeatherDbContext(DbContextOptions options) : base(options)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherDbContext).Assembly);
        //SEQUENCE
        modelBuilder.HasSequence<long>("SQ_Hilo_City").StartsAt(1).IncrementsBy(1);

    }
}