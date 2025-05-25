
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Entities.Cities;
using WeatherApi.Persistence.EF.Hilo;

namespace WeatherApi.Persistence.EF.Repositories.Cities;

public class CityRepository : ICityRepository
{
    private readonly WeatherDbContext dbcontext;
    private readonly IHiloIdGenerator hiloIdGenerator;

    public CityRepository(WeatherDbContext dbcontext, IHiloIdGenerator hiloIdGenerator)
    {
        this.dbcontext = dbcontext;
        this.hiloIdGenerator = hiloIdGenerator;
    }
    public long GetNextId()
    {
        return hiloIdGenerator.GetNextId<City>();
    }
    public async Task Add(City city, CancellationToken token)
    {
        await dbcontext.AddAsync(city,token);
        await dbcontext.SaveChangesAsync(token);
    }
    public async Task<City> Get(long id, CancellationToken token)
    {
        return await dbcontext.Cities.Include(x=>x.Stations).SingleAsync(x => x.Id == id);
    }
    public async Task Update(CancellationToken token)
    {
        await dbcontext.SaveChangesAsync(token);
    }
}
