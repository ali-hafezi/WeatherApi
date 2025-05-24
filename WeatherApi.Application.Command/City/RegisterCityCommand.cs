using MediatR;
using System.Text.Json.Serialization;

namespace WeatherApi.Application.Command.City;

public class RegisterCityCommand: IRequest<long>
{
    [JsonIgnore]public long Id {  get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
