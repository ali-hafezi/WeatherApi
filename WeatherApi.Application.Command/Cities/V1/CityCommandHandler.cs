

using MediatR;
using WeatherApi.Application.Command.Cities.V1.Mapper;
using WeatherApi.Domain.Entities.Cities;

namespace WeatherApi.Application.Command.Cities.V1;

public class CityCommandHandler : 
    IRequestHandler<RegisterCityCommand, long>,
    IRequestHandler<RemoveCityCommand, long>,
    IRequestHandler<ModifyCityCommand, long>,
    IRequestHandler<RegisterStationCommand, long>,
    IRequestHandler<ModifyStationCommand, long>,
    IRequestHandler<RemoveStationCommand, long>
{
    private readonly ICityRepository repository;

    public CityCommandHandler(ICityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<long> Handle(RegisterCityCommand command, CancellationToken token)
    {
        command.Id = repository.GetNextId();
        var arg= CityMapper.Map(command);
        var city = await City.New(arg, null, token);
        await repository.Add(city,token);
        return command.Id;
    }
    public async Task<long> Handle(ModifyCityCommand command, CancellationToken token)
    {
        var city = await repository.Get(command.Id, token);
        var arg = CityMapper.Map(command);
        city.Modify(arg,null, token);
        await repository.Update(token);
        return city.Id;
    }

    public async Task<long> Handle(RemoveCityCommand command, CancellationToken token)
    {
        var city = await repository.Get(command.Id, token);
        city.Remove();
        await repository.Update(token);
        return city.Id;
    }

    public async Task<long> Handle(RegisterStationCommand command, CancellationToken token)
    {
        var city=await repository.Get(command.CityId, token);
        var arg=CityMapper.Map(command);
        await city.RegisterStation(arg, null, token);
        await repository.Update(token);
        return city.Id;
    }

    public async Task<long> Handle(ModifyStationCommand command, CancellationToken token)
    {
        var city = await repository.Get(command.CityId, token);
        var arg = CityMapper.Map(command);
        await city.ModifyStation(arg, null, token);
        await repository.Update(token);
        return city.Id;
    }

    public async Task<long> Handle(RemoveStationCommand command, CancellationToken token)
    {
        var city = await repository.Get(command.CityId, token);
        city.RemoveStation(command.Id);
        await repository.Update(token);
        return command.Id;
    }
}
