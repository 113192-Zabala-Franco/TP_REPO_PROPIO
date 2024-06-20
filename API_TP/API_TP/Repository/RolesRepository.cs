using API_TP.Data;

namespace API_TP.Repository
{
    public class RolesRepository
    {
        private readonly ContextTP _contexto;

        public RolesRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }
    }
}
