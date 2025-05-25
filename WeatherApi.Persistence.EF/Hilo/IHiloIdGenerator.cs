
namespace WeatherApi.Persistence.EF.Hilo;

public interface IHiloIdGenerator
{
    long GetNextId<T>();
}
