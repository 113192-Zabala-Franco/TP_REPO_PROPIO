using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.Models
{
    [Table("AlumnosXCursos")]
    public class AlumnosXCursos
    {
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; }

        public int IdCurso { get; set; }
        [ForeignKey("IdCurso")] public Cursos Cursos { get; set; }


        public int IdAlumno { get; set; }
        [ForeignKey("IdAlumno")] public Alumnos Alumnos { get; set; }
    }
}
