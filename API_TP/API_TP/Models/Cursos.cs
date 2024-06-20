using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.Models
{
    [Table("Cursos")]
    public class Cursos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Horarios {  get; set; }
        public int IdCarrera { get; set; }

        [ForeignKey("IdCarrera")] public Carreras Carreras { get; set; }
    }
}
