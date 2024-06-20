using API_TP.DTOS;
using API_TP.Interfaces;
using API_TP.Interfaces.ICursos;
using API_TP.Query.Alumnos;
using API_TP.Query.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Controllers
{
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoServices _cursosServices;

        public CursosController(ICursoServices cursosServices)
        {
            _cursosServices = cursosServices;
        }

        [HttpGet("Cursos/GETALL")]
        public async Task<IActionResult> GetAll()
        {
            var cursos = await _cursosServices.GetAllCursos();
            return Ok(cursos);
        }

        [HttpGet("Cursos/GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _cursosServices.GetCursoById(id);
            return Ok(curso);
        }

        [HttpPost("Cursos/NuevoAlumno")]
        public async Task<IActionResult> NuevoCurso([FromBody] NuevoCursoQuery query)
        {
            var curso = await _cursosServices.PostCurso(query);
            return Ok(curso);

        }

        [HttpPut("Cursos/Modificar")]
        public async Task<IActionResult> ModificarAlumno([FromBody] NuevoCursoQuery query)
        {
            var respuesta = await _cursosServices.PutCurso(query);

            if (!respuesta.Success)
            {
                return NotFound(respuesta.MensajeError);
            }

            return Ok(respuesta);
        }

        [HttpDelete("Cursos/Eliminar")]

        public async Task<IActionResult> EliminarCurso(int id)
        {
            var respuesta = await _cursosServices.DeleteCursoById(id);

            if (!respuesta.Success)
            {
                return NotFound(respuesta.MensajeError);
            }

            return Ok(respuesta);
        }
    }
}
