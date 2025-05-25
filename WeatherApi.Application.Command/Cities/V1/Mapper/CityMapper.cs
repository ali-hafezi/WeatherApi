
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
}
