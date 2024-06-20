using API_TP.Data;

namespace API_TP.Repository
{
    public class AlumnosXCursosRepository
    {
        private readonly ContextTP _contexto;

        public AlumnosXCursosRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }
    }
}
