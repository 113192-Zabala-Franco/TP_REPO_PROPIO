using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.Models
{
    [Table("Docentes")]
    public class Docentes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Legajo { get; set; }

        public int IdRoles { get; set; }
        [ForeignKey("IdRoles")] public Roles Roles { get; set; }
    }
}
