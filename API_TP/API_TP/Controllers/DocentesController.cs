using API_TP.Interfaces;
using API_TP.Interfaces.IDocentes;
using API_TP.Query.Alumnos;
using API_TP.Query.Docentes;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Controllers
{
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly IDocenteServices _docenteServices;

        public DocentesController(IDocenteServices docenteServices)
        {
            _docenteServices = docenteServices;
        }

        [HttpGet("Docentes/GETALL")]
        public async Task<IActionResult> GetAll()
        {
            var docentes = await _docenteServices.GetAllDocentes();
            return Ok(docentes);
        }

        [HttpGet("Docentes/GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var docenteId = await _docenteServices.GetDocenteById(id);
            return Ok(docenteId);
        }


        [HttpPost("Docentes/NuevoAlumno")]
        public async Task<IActionResult> NuevoAlumno([FromBody] NuevoDocenteQuery query)
        {
            var alu = await _docenteServices.PostDocente(query);
            return Ok(alu);

        }

        [HttpPut("Docentes/Modificar")]
        public async Task<IActionResult> ModificarAlumno([FromBody] NuevoDocenteQuery query)
        {
            var respuesta = await _docenteServices.PutDocente(query);

            if (!respuesta.Success)
            {
                return NotFound(respuesta.MensajeError);
            }

            return Ok(respuesta);
        }

        [HttpDelete("Docentes/Eliminar")]

        public async Task<IActionResult> EliminarAlumno(int id)
        {
            var respuesta = await _docenteServices.DeleteDocenteById(id);

            if (!respuesta.Success)
            {
                return NotFound(respuesta.MensajeError);
            }

            return Ok(respuesta);
        }
    }
}
