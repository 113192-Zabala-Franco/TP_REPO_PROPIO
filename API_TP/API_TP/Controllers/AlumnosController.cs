using API_TP.DTOS;
using API_TP.Interfaces;
using API_TP.Query.Alumnos;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Controllers
{
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoServices _alumnoServices;

        public AlumnosController(IAlumnoServices alumnoServices)
        {
            _alumnoServices = alumnoServices;
        }

        [HttpGet("Alumnos/GETALL")]
        public async Task<IActionResult> GetAll()
        {
            var alumnos = await _alumnoServices.GetAllAlumnos();
            return Ok(alumnos);
        }

        [HttpGet("Alumnos/GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var alumnoId = await _alumnoServices.GetAlumnoById(id);
            return Ok(alumnoId);
        }

        [HttpPost("Alumnos/NuevoAlumno")]
        public async Task<IActionResult> NuevoAlumno([FromBody] NuevoAlumnoQuery query)
        {
            var alu = await _alumnoServices.PostAlumno(query);
            return Ok(alu);

        }

        [HttpPut("Alumnos/Modificar")]
        public async Task<IActionResult> ModificarAlumno([FromBody] NuevoAlumnoQuery query)
        {
            var respuesta = await _alumnoServices.PutAlumno(query);

            if (!respuesta.Success)
            {
                return NotFound(respuesta.MensajeError);
            }

            return Ok(respuesta);
        }

        [HttpDelete("Alumnos/Eliminar")]

        public async Task<IActionResult> EliminarAlumno(int id)
        {
            var respuesta = await _alumnoServices.DeleteAlumnoById(id);

            if (!respuesta.Success)
            {
                return NotFound(respuesta.MensajeError);
            }

            return Ok(respuesta);
        }
    }
}
