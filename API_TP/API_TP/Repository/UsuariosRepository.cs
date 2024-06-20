using API_TP.Data;

namespace API_TP.Repository
{
    public class UsuariosRepository
    {
        private readonly ContextTP _contexto;

        public UsuariosRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }
    }
}
