
using MediatR;

namespace WeatherApi.RestApi.Common;

public class CommandBus : ICommandBus
{
    private readonly ISender _sender;

    public CommandBus(ISender sender)
    {
        _sender = sender;
    }

    public Task<TResult> Send<TResult>(IRequest<TResult> command, CancellationToken cancellationToken = default)
    {
        return _sender.Send(command, cancellationToken);
    }
}
