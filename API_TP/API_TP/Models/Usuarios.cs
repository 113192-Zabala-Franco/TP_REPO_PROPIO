using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public int IdRoles { get; set; }
        [ForeignKey("IdRoles")] public Roles Roles { get; set; }
    }
}
