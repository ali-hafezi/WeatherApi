
using WeatherApi.Domain.Entities.Cities.Args;

namespace WeatherApi.Application.Command.Cities.V1.Mapper;

public abstract class CityMapper
{
    public static RegisterCityArg Map(RegisterCityCommand cityCommand)
    {
        return new RegisterCityArg
        {
            Id = cityCommand.Id,
            Name = cityCommand.Name,
            Latitude = cityCommand.Latitude,
            Longitude = cityCommand.Longitude,
        };
    }
    public static ModifyCityArg Map(ModifyCityCommand cityCommand)
    {
        return new ModifyCityArg
        {
            Id = cityCommand.Id,
            Name = cityCommand.Name,
            Latitude = cityCommand.Latitude,
            Longitude = cityCommand.Longitude,
        };
    }
    public static RegisterStationArg Map(RegisterStationCommand stationCommand)
    {
        return new RegisterStationArg
        {
            Id = stationCommand.Id,
            Name = stationCommand.Name,
            Latitude = stationCommand.Latitude,
            Longitude = stationCommand.Longitude,
            CityId = stationCommand.CityId,
        };
    }
    public static ModifyStationArg Map(ModifyStationCommand stationCommand)
    {
        return new ModifyStationArg
        {
            Id = stationCommand.Id,
            Name = stationCommand.Name,
            Latitude = stationCommand.Latitude,
            Longitude = stationCommand.Longitude,
            CityId = stationCommand.CityId,
        };
    }
}
