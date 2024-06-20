namespace API_TP.Query.Cursos
{
    public class NuevoCursoQuery
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Horarios { get; set; }
        public int IdCarrera { get; set; }
    }
}
