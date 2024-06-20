using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.DTOS
{
    public class DocentesXCursosDto
    {

        public DateTime FechaAlta { get; set; }

        public int IdCurso { get; set; }
        [ForeignKey("IdCurso")] public CursosDto Cursos { get; set; }


        public int IdDocente { get; set; }
        [ForeignKey("IdDocente")] public DocentesDto Docentes { get; set; }
    }
}
