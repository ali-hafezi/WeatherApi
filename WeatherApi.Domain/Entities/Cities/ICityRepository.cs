
using WeatherApi.Domain.Common;

namespace WeatherApi.Domain.Entities.Cities;

public interface ICityRepository :IRepository<City>
{
    long GetNextId();
    Task Add(City city, CancellationToken token);
    Task Update(CancellationToken token);
    Task<City> Get(long id, CancellationToken token);

}
