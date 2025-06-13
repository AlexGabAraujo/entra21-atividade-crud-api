using MySql.Data.MySqlClient;

namespace MinhaPrimeiraApi.Contracts.Connection
{
    public interface IConnection
    {
        MySqlConnection GetConnection();

        Task<int> Execute(string sql, object obj);
    }
}