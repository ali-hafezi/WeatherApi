using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.RestApi.Common;

public class BaseController:ControllerBase
{
    protected readonly ICommandBus commandBus;
    protected readonly IQueryBus queryBus;
    public BaseController(ICommandBus commandBus, IQueryBus queryBus)
    {
        this.commandBus = commandBus;
        this.queryBus = queryBus;
    }
}