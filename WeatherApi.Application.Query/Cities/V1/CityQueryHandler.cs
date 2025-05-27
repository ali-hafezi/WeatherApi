

using Dapper;
using MediatR;
using WeatherApi.Read.Dapper.Common;

namespace WeatherApi.Application.Query.Cities.V1;

public class CityQueryHandler :
    IRequestHandler<GetCityQuery, GetCityDto>,
    IRequestHandler<GetCitiesQuery, IEnumerable<GetCityDto>>
{
    private IDapperQuery dapperQuery;
    public CityQueryHandler(IDapperQuery dapperQuery)
    {
        this.dapperQuery = dapperQuery;
    }
    public async Task<GetCityDto> Handle(GetCityQuery query, CancellationToken token)
    {
        const string sql = "SELECT [Id]"+
                           "   ,[Name]"+
                           "   ,[location_Latitude]"+
                           "   ,[location_Longitude]"+
                           "FROM [WeatherApiCore].[dbo].[Cities]"+
                           "Where [Id]=@Id AND [IsDeleted] = 0";

        GetCityDto result;

        using (var connection = dapperQuery.CreateConnection())
        {
            result = await connection.QueryFirstOrDefaultAsync<GetCityDto>(sql, new { query.Id });
        }

        return result;
    }

    public async Task<IEnumerable<GetCityDto>> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
    {
        const string sql = "SELECT [Id]" +
                           "   ,[Name]" +
                           "   ,[location_Latitude]" +
                           "   ,[location_Longitude]" +
                           "FROM [WeatherApiCore].[dbo].[Cities]" +
                           "Where [IsDeleted] = 0";

        IEnumerable<GetCityDto>? result;

        using (var connection = dapperQuery.CreateConnection())
        {
            result = await connection.QueryAsync<GetCityDto>(sql,query);
        }

        return result;
    }
}
