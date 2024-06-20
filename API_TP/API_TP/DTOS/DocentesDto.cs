using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.DTOS
{
    public class DocentesDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Legajo { get; set; }

        public int IdRoles { get; set; }
        [ForeignKey("IdRoles")] public RolesDto Roles { get; set; }
    }
}
