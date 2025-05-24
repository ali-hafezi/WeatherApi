
using MediatR;

namespace WeatherApi.RestApi.Common;

public interface ICommandBus
{
    Task<TResult> Send<TResult>(IRequest<TResult> command, CancellationToken cancellationToken = default);
}
