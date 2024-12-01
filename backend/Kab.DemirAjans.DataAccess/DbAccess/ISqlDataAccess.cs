
namespace Kab.DemirAjans.DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task<int> SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default");
}