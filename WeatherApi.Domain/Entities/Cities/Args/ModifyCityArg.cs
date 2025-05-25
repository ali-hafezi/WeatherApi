
namespace WeatherApi.Domain.Entities.Cities.Args;

public class ModifyCityArg
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

}
