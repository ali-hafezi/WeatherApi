
using MediatR;

namespace WeatherApi.RestApi.Common;

public interface IQueryBus
{
    Task<TResult> Send<TResult>(IRequest<TResult> query, CancellationToken cancellationToken = default);
}
