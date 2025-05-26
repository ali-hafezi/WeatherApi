
using MediatR;

namespace WeatherApi.RestApi.Common;

public class CommandBus : ICommandBus
{
    private readonly ISender _sender;

    public CommandBus(ISender sender)
    {
        _sender = sender;
    }

    public async Task<TResult> DispatchAsync<TResult>(IRequest<TResult> command, CancellationToken token = default)
    {
        return await _sender.Send(command, token);
    }
}
