using WeatherApi.Domain.Common;
using WeatherApi.Domain.Entities.Cities.Args;
using WeatherApi.Domain.ValueObjects;

namespace WeatherApi.Domain.Entities.Cities;

public class City: BaseEntity
{
    public string Name { get; set; }
    public GeoLocation Location { get; set; }
    private readonly List<Station> _stations = [];
    public IEnumerable<Station> Stations => _stations.AsReadOnly();
    private City() { }
    private City(RegisterCityArg arg)
    {
        Id = arg.Id;
        Name = arg.Name;
        Location = new GeoLocation { Latitude = arg.Latitude, Longitude = arg.Longitude };
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
        Location.Latitude = arg.Latitude ?? Location.Latitude;
        Location.Longitude = arg.Longitude ?? Location.Longitude;
    }
    public void Remove()
    {
        ///////Logic
        IsDeleted = true;
        DeleteTime = DateTime.UtcNow;
    }
    public async Task RegisterStation(RegisterStationArg arg, ICityService service, CancellationToken token)
    {
        _stations.Add(await Station.New(arg, service, token));
    }
    public async Task ModifyStation(ModifyStationArg arg, ICityService service, CancellationToken token)
    {
        var station = _stations.Find(x => x.Id == arg.Id);
        await station.Modify(arg, service, token);
    }
    public void RemoveStation(long id)
    {
        var station = _stations.Find(x => x.Id == id);
        station.Remove();
    }
}
