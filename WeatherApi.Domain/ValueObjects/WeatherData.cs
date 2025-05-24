using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Common;

namespace WeatherApi.Domain.ValueObjects;
[Owned]
public class WeatherData: ValueObject
{
    public double temperature {  get; set; }
    public double pressure { get; set; }
    public int humidity {  get; set; }
    public double windSpeed { get; set; }
    public double windDirection { get; set; }
}
