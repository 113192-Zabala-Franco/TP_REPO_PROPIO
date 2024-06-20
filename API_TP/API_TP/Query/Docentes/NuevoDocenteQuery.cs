namespace API_TP.Query.Docentes
{
    public class NuevoDocenteQuery
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Legajo { get; set; }

        public int IdRoles { get; set; }
    }
}
