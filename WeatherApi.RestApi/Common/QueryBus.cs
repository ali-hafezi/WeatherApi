
using MediatR;

namespace WeatherApi.RestApi.Common;

public class QueryBus : IQueryBus
{
    private readonly ISender _sender;

    public QueryBus(ISender sender)
    {
        _sender = sender;
    }

    public Task<TResult> Send<TResult>(IRequest<TResult> query, CancellationToken cancellationToken = default)
    {
        return _sender.Send(query, cancellationToken);
    }
}
