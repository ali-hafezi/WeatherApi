

using MediatR;
using System.Text.Json.Serialization;

namespace WeatherApi.Application.Command.Cities.V1;

public record class RemoveStationCommand:IRequest<long>
{
    [JsonIgnore]public long Id { get; set; }
    [JsonIgnore]public long CityId { get; set; }
}
