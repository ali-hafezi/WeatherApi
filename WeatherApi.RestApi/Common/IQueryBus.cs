
using MediatR;

namespace WeatherApi.RestApi.Common;

public interface IQueryBus
{
    Task<TResult> DispatchAsync<TResult>(IRequest<TResult> query, CancellationToken token = default);
}
