using API_TP.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.DTOS
{
    public class AlumnosXCursosDto
    {

        public int IdCurso { get; set; }
        [ForeignKey("IdCurso")] public CursosDto Cursos { get; set; }


        public int IdAlumno { get; set; }
        [ForeignKey("IdAlumno")] public AlumnosDto Alumnos { get; set; }
    }
}
