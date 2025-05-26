

namespace WeatherApi.Application.Query.Cities.V1;

public record class GetCityDto(long Id,string Name,double location_Latitude, double location_Longitude);
