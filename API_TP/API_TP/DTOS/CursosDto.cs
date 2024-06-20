using System.ComponentModel.DataAnnotations.Schema;

namespace API_TP.DTOS
{
    public class CursosDto
    {
        public string Nombre { get; set; }

        public string Horarios {  get; set; }

        public int IdCarrera { get; set; }

        [ForeignKey("IdCarrera")] public CarrerasDto Carreras { get; set; }
    }
}
