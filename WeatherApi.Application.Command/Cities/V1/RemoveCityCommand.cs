

using MediatR;

namespace WeatherApi.Application.Command.Cities.V1;

public class RemoveCityCommand:IRequest<long>
{
    public long Id { get; set; }
}
