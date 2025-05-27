
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Common;
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

        modelBuilder.Entity<City>().Property(p => p.Id).ValueGeneratedNever();
        modelBuilder.Entity<WeatherReport>().Property(p => p.Id).ValueGeneratedNever();

        //SEQUENCE
        modelBuilder.HasSequence<long>("SQ_Hilo_City").StartsAt(1).IncrementsBy(1);
        modelBuilder.HasSequence<long>("SQ_Hilo_WeatherReport").StartsAt(1).IncrementsBy(1);

        modelBuilder.Entity<City>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<Station>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<WeatherReport>().HasQueryFilter(c => !c.IsDeleted);

    }

}