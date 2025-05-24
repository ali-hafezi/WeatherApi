
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Application.Command.City;
using WeatherApi.RestApi.Common;

namespace WeatherApi.RestApi.City.V1;

[Route("api/v1.0/[controller]")]
[ApiController]

public class CityController: BaseController
{
    public CityController(ICommandBus commandBus, IQueryBus queryBus) : 
        base(commandBus, queryBus){}

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Version 1.0 - City endpoint");
    }
    [HttpPost]
    public async Task<ActionResult> Post(RegisterCityCommand command, CancellationToken token)
    {
        var result=await _commandBus.Send(command,token);
        return Ok(result);
    }
}
