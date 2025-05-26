
using MediatR;

namespace WeatherApi.Application.Query.Cities.V1;

public record class GetCityQuery(long Id) : IRequest<GetCityDto>;
