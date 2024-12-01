using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using System;

namespace Kab.DemirAjans.DataAccess.DbAccess;

public class SqlDataAccess(IConfiguration configuration) : ISqlDataAccess
{
    private readonly IConfiguration Configuration = configuration;

    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(Configuration.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(Configuration.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}