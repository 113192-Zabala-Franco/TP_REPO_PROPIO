using API_TP.Data;

namespace API_TP.Repository
{
    public class DocentesXCursosRepository
    {
        private readonly ContextTP _contexto;

        public DocentesXCursosRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }
    }
}
