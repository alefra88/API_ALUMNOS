using ALUMNOS_API_TRES.Models;
using ALUMNOS_API_TRES.Repositories.Interfaces;
using ALUMNOS_API_TRES.Services.Interfaces;

namespace ALUMNOS_API_TRES.Services.Impl
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IAlumnoRepository _repository;
        public AlumnoService(IAlumnoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAlumnoAsync(Alumnos alumnos)
        {
            await _repository.AddAlumnoAsync(alumnos);
        }

        public async Task DeleteAlumnoAsync(int id)
        {
            await _repository.DeleteAlumnoAsync(id);
        }

        public async Task<List<Alumnos>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Alumnos?> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task UpdateAlumnoAsync(Alumnos alumnos)
        {
            await _repository.UpdateAlumnoAsync(alumnos);
        }
    }
}
