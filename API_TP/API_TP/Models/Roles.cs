using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.Models
{
    [Table("Roles")]
    public class Roles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
