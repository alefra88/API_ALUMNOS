using ALUMNOS_API_TRES.Models;
using ALUMNOS_API_TRES.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALUMNOS_API_TRES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        public AlumnosController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        // GET: api/<AlumnosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alumnos = await _alumnoService.GetAsync();
            return Ok(alumnos);
        }

        // GET api/<AlumnosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var alumno = await _alumnoService.GetAsync(id);
            return Ok(alumno);
        }

        // POST api/<AlumnosController>
        [HttpPost]
        public async Task Post([FromBody] Alumnos alumnos)
        {
            await _alumnoService.AddAlumnoAsync(alumnos);
        }

        // PUT api/<AlumnosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumnos alumnos)
        {
            var existingAlumno = await _alumnoService.GetAsync(id);
            if (existingAlumno == null)
            {
                return NotFound(); 
            }

            alumnos.Id = id; 
            await _alumnoService.UpdateAlumnoAsync(alumnos);

            return NoContent(); 
        }

        // DELETE api/<AlumnosController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _alumnoService.DeleteAlumnoAsync(id);
        }
    }
}
