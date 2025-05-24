using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Common;

namespace WeatherApi.Domain.ValueObjects;
[Owned]
public class GeoLocation: ValueObject
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
