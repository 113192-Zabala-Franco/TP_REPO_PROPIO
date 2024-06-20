using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.Models
{
    [Table("DocentesXcursos")]
    public class DocentesXCursos
    {
        public int Id { get; set; }

        public DateTime FechaAlta { get; set; }

        public int IdCurso { get; set; }
        [ForeignKey("IdCurso")] public Cursos Cursos { get; set; }


        public int IdDocente { get; set; }
        [ForeignKey("IdDocente")] public Docentes Docentes { get; set; }
    }
}
