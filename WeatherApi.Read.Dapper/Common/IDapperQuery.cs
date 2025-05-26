
using System.Data;

namespace WeatherApi.Read.Dapper.Common;

public interface IDapperQuery
{
    IDbConnection CreateConnection();
}
