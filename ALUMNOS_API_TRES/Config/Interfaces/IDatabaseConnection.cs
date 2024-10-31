using System.Data.SqlClient;

namespace ALUMNOS_API_TRES.Config.Interfaces
{
    public interface IDatabaseConnection
    {
        Task<SqlConnection> DbConnectionAsync();
    }
}
