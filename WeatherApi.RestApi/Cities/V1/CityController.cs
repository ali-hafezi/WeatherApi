
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Application.Command.Cities.V1;
using WeatherApi.RestApi.Common;

namespace WeatherApi.RestApi.Cities.V1;

[Route("api/v1/[controller]")]
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
        var result = await _commandBus.Send(command, token);
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(long id, [FromBody] ModifyCityCommand command, CancellationToken token)
    {
        command.Id = id;
        var result = await _commandBus.Send(command, token);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(RemoveCityCommand command, CancellationToken token)
    {
        var result = await _commandBus.Send(command, token);
        return Ok(result);
    }

}
