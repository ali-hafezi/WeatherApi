

using MediatR;

namespace WeatherApi.Application.Command.Cities.V1;

public record class RemoveCityCommand:IRequest<long>
{
    public long Id { get; set; }
}
