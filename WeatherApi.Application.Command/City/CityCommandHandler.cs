

using MediatR;

namespace WeatherApi.Application.Command.City;

public class CityCommandHandler : IRequestHandler<RegisterCityCommand, long>
{

    public async Task<long> Handle(RegisterCityCommand request, CancellationToken cancellationToken)
    {
        return 5;
    }
}
