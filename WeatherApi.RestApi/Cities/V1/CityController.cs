
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Application.Command.Cities.V1;
using WeatherApi.Application.Query.Cities.V1;
using WeatherApi.RestApi.Common;

namespace WeatherApi.RestApi.Cities.V1;

[Route("api/v1/[controller]")]
[ApiController]

public class CityController: BaseController
{
    public CityController(ICommandBus commandBus, IQueryBus queryBus) : 
        base(commandBus, queryBus){}

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCityDto>> Get(long id, CancellationToken token)
    {
        var result = await queryBus.DispatchAsync(new GetCityQuery(id), token);
        return Ok(result);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCityDto>>> Get([FromQuery]GetCitiesQuery query,CancellationToken token)
    {
        var result = await queryBus.DispatchAsync(query,token);
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult> Post(RegisterCityCommand command, CancellationToken token)
    {
        var result = await commandBus.DispatchAsync(command, token);
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(long id, [FromBody] ModifyCityCommand command, CancellationToken token)
    {
        command.Id = id;
        var result = await commandBus.DispatchAsync(command, token);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(RemoveCityCommand command, CancellationToken token)
    {
        var result = await commandBus.DispatchAsync(command, token);
        return Ok(result);
    }

}
