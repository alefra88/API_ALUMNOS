using ALUMNOS_API_TRES.Config.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ALUMNOS_API_TRES.Config.Impl
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly string _connection;
        public DatabaseConnection(IConfiguration configuration) => _connection = configuration.GetConnectionString("Connection")
            ?? throw new ArgumentNullException(nameof(configuration));
        public async Task<SqlConnection> DbConnectionAsync()
        {
            var con = new SqlConnection(_connection);
            await con.OpenAsync();
            return con;
        }
    }
}
