
using WeatherApi.Domain.Common;
using WeatherApi.Domain.ValueObjects;

namespace WeatherApi.Domain.Entities.City;

public class Station:BaseEntity
{
    public string Name { get; set; }
    public GeoLocation Location { get; set; }
    public long CityId { get; set; }
    public City City { get; set; }
}
