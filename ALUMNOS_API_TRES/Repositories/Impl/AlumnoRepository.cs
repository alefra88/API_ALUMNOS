using ALUMNOS_API_TRES.Config.Interfaces;
using ALUMNOS_API_TRES.Models;
using ALUMNOS_API_TRES.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ALUMNOS_API_TRES.Repositories.Impl
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly IDatabaseConnection _connection;
        public AlumnoRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }
        public async Task AddAlumnoAsync(Alumnos alumnos)
        {
            var query = "agregarAlumnos";
            using var con = await _connection.DbConnectionAsync();
            using var command = new SqlCommand(query, con)
            {
                CommandType = CommandType.StoredProcedure
            };
            AddParameters(command,alumnos);
            if (con.State != ConnectionState.Open)
            {
                await con.OpenAsync();
            }
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAlumnoAsync(int id)
        {
            var query = "EliminarAlumnos";
            using var con = await _connection.DbConnectionAsync();
            using var command = new SqlCommand(query, con)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("id", id);
            if (con.State != ConnectionState.Open)
            {
                await con.OpenAsync();
            }
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Alumnos>> GetAsync()
        {
            var alumnos = new List<Alumnos>();
            var query = "consultarAlumnos2";
            using(SqlConnection con = await  _connection.DbConnectionAsync())
            {
                using var command = new SqlCommand(query, con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", -1);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var alumno = MapReaderAlumnos(reader);
                    alumnos.Add(alumno);
                }
            }
            return alumnos;
        }

        private static Alumnos MapReaderAlumnos(SqlDataReader reader)
        {
            return new Alumnos
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? null : reader.GetString(reader.GetOrdinal("nombre")),
                PrimerApellido = reader.IsDBNull(reader.GetOrdinal("primerApellido")) ? null : reader.GetString(reader.GetOrdinal("primerApellido")),
                SegundoApellido = reader.IsDBNull(reader.GetOrdinal("segundoApellido")) ? null : reader.GetString(reader.GetOrdinal("segundoApellido")),
                Correo = reader.IsDBNull(reader.GetOrdinal("correo")) ? null : reader.GetString(reader.GetOrdinal("correo")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString(reader.GetOrdinal("telefono")),
                FechaNacimiento = reader.IsDBNull(reader.GetOrdinal("fechaNacimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fechaNacimiento")),
                Curp = reader.IsDBNull(reader.GetOrdinal("curp")) ? null : reader.GetString(reader.GetOrdinal("curp")),
                SueldoMensual = reader.IsDBNull(reader.GetOrdinal("sueldoMensual")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("sueldoMensual")),
                IdEstadoOrigen = reader.IsDBNull(reader.GetOrdinal("id")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id")),
                IdEstatus = reader.IsDBNull(reader.GetOrdinal("id")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id")),
            };
        }

        public async Task<Alumnos?> GetAsync(int id)
        {
            var query = "consultarAlumnos2"; 
            using var con = await _connection.DbConnectionAsync();
            using var command = new SqlCommand(query, con)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@id", id);

            if (con.State != ConnectionState.Open)
            {
                await con.OpenAsync();
            }

            using var reader = await command.ExecuteReaderAsync();

            
            if (await reader.ReadAsync())
            {
                return MapReaderAlumnos(reader); 
            }

            return null; 
        }


        public async Task UpdateAlumnoAsync(Alumnos alumnos)
        {
            var query = "actualizarAlumnos"; 
            using var con = await _connection.DbConnectionAsync();
            using var command = new SqlCommand(query, con)
            {
                CommandType = CommandType.StoredProcedure
            };

            AddParameters(command, alumnos);

            if (con.State != ConnectionState.Open)
            {
                await con.OpenAsync();
            }

            await command.ExecuteNonQueryAsync();
        }

        private static void AddParameters(SqlCommand command, Alumnos alumnos)
        {
            command.Parameters.AddWithValue("@id", alumnos.Id);
            command.Parameters.AddWithValue("@nombre", alumnos.Nombre);
            command.Parameters.AddWithValue("@primerApellido", alumnos.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", alumnos.SegundoApellido);
            command.Parameters.AddWithValue("@correo", alumnos.Correo);
            command.Parameters.AddWithValue("@telefono", alumnos.Telefono);
            command.Parameters.AddWithValue("@fechaNacimiento", alumnos.FechaNacimiento);
            command.Parameters.AddWithValue("@curp", alumnos.Curp);
            command.Parameters.AddWithValue("@sueldoMensual", alumnos.SueldoMensual);
            command.Parameters.AddWithValue("@idEstadoOrigen", alumnos.IdEstadoOrigen);
            command.Parameters.AddWithValue("@idEstatus", alumnos.IdEstatus);
        }
    }
}
