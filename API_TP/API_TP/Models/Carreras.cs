using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.Models
{
    [Table("Carreras")]
    public class Carreras
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
