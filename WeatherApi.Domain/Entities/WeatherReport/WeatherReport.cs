
using WeatherApi.Domain.Common;
using WeatherApi.Domain.Entities.City;
using WeatherApi.Domain.ValueObjects;

namespace WeatherApi.Domain.Entities.WeatherReport;

public class WeatherReport :BaseEntity
{
    public long StationId { get; set; }
    public DateTime RecordTime { get; set; }
    public WeatherData WeatherData { get; set; }
    public Station Station { get; set; }
}
