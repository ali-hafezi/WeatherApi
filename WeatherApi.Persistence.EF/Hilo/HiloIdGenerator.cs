using Microsoft.EntityFrameworkCore;


namespace WeatherApi.Persistence.EF.Hilo;

public class HiloIdGenerator : IHiloIdGenerator
{
    private readonly WeatherDbContext _context;

    public HiloIdGenerator(WeatherDbContext context)
    {
        _context = context;
    }

    public long GetNextId<T>()
    {
        var sequenceName = $"SQ_Hilo_{typeof(T).Name}";
        var sql = $"SELECT NEXT VALUE FOR {sequenceName}";

        var connection = _context.Database.GetDbConnection();

        using var command = connection.CreateCommand();
        command.CommandText = sql;

        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        var result = command.ExecuteScalar();
        return Convert.ToInt64(result);

    }
}
