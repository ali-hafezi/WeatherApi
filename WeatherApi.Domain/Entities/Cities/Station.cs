
using WeatherApi.Domain.Common;
using WeatherApi.Domain.Entities.Cities.Args;
using WeatherApi.Domain.ValueObjects;

namespace WeatherApi.Domain.Entities.Cities;

public class Station:BaseEntity
{
    public string Name { get; set; }
    public GeoLocation Location { get; set; }
    public long CityId { get; set; }
    public City City { get; set; }
    private Station() { }
    private Station(RegisterStationArg arg) 
    {
        Id = arg.Id;
        Name = arg.Name;
        Location = new GeoLocation { Latitude = arg.Latitude, Longitude = arg.Longitude };
        CityId=arg.CityId;
    }

    public static async Task<Station> New(RegisterStationArg arg, ICityService service, CancellationToken token)
    {
        ///////////Logic
        return new Station(arg);
    }
    public async Task Modify(ModifyStationArg arg, ICityService service, CancellationToken token)
    {
        /////////Logic
        Name= arg.Name;
        Location = new GeoLocation {Latitude=arg.Latitude, Longitude=arg.Longitude};
    }
    public void Remove()
    {
        IsDeleted = true;
        DeleteTime = DateTime.UtcNow;
    }

}
