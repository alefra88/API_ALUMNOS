using ALUMNOS_API_TRES.Models;

namespace ALUMNOS_API_TRES.Repositories.Interfaces
{
    public interface IAlumnoRepository
    {
        Task<List<Alumnos>> GetAsync();
        Task<Alumnos?> GetAsync(int id);
        Task AddAlumnoAsync(Alumnos alumnos);
        Task UpdateAlumnoAsync(Alumnos alumnos);
        Task DeleteAlumnoAsync(int id);
    }
}
