using API_TP.Data;

namespace API_TP.Repository
{
    public class CarrerasRepository
    {
        private readonly ContextTP _contexto;

        public CarrerasRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }
    }
}
