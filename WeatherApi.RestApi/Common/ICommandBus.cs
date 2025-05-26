
using MediatR;

namespace WeatherApi.RestApi.Common;

public interface ICommandBus
{
    Task<TResult> DispatchAsync<TResult>(IRequest<TResult> command, CancellationToken token = default);
}
