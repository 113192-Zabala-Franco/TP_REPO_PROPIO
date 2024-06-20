using API_TP.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.DTOS
{
    public class AlumnosDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Legajo { get; set; }
        public string NombreRol {  get; set; }

    }
}
