using WeatherApi.Domain.Common;
using WeatherApi.Domain.ValueObjects;

namespace WeatherApi.Domain.Entities.City;

public class City: BaseEntity
{
    public string Name { get; set; }
    public GeoLocation location { get; set; }
    private readonly List<Station> _stations = [];
    public IEnumerable<Station> Stations => _stations.AsReadOnly();
}
