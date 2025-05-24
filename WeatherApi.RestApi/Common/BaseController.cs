using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.RestApi.Common;

public class BaseController:ControllerBase
{
    protected readonly ICommandBus _commandBus;
    protected readonly IQueryBus _queryBus;
    public BaseController(ICommandBus commandBus, IQueryBus queryBus)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
    }
}