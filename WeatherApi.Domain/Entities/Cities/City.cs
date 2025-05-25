using WeatherApi.Domain.Common;
using WeatherApi.Domain.Entities.Cities.Args;
using WeatherApi.Domain.ValueObjects;

namespace WeatherApi.Domain.Entities.Cities;

public class City: BaseEntity
{
    public string Name { get; set; }
    public GeoLocation location { get; set; }
    private readonly List<Station> _stations = [];
    public IEnumerable<Station> Stations => _stations.AsReadOnly();
    private City() { }
    private City(RegisterCityArg arg)
    {
        Id = arg.Id;
        Name = arg.Name;
        location= new GeoLocation { Latitude = arg.Latitude, Longitude = arg.Longitude };
    }
    public static async Task<City> New(RegisterCityArg arg, ICityService service, CancellationToken token)
    {
        ///////////Logic
        return new City(arg);
    }
    public async Task Modify(ModifyCityArg arg, ICityService service, CancellationToken token)
    {
        ///////////Logic
        Name = arg.Name ?? Name;
        location.Latitude = arg.Latitude ?? location.Latitude;
        location.Longitude = arg.Longitude ?? location.Longitude;
    }
    public void Remove()
    {
        ///////Logic
        IsDeleted = true;
        DeleteTime = DateTime.UtcNow;
    }
}
