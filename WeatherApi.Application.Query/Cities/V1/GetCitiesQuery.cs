
using MediatR;

namespace WeatherApi.Application.Query.Cities.V1;

public record class GetCitiesQuery() : IRequest<IEnumerable<GetCityDto>>;
