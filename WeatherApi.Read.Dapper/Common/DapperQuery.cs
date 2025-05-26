
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WeatherApi.Read.Dapper.Common;

public class DapperQuery:IDapperQuery
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public DapperQuery(string cnn)
    {
        _connectionString = cnn;
    }
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
