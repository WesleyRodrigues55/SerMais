using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class TipoProfissionalRepositorio : ITipoProfissionalRepositorio
    {
        private readonly BancoContext _bancoContext;

        public TipoProfissionalRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public void Atualizar(TipoProfissionalModel tipo_profissional)
        {
            _bancoContext.Entry(tipo_profissional).State = EntityState.Modified;
            _bancoContext.SaveChanges();
        }
        public TipoProfissionalModel ObterPorId(int id)
        {
            return _bancoContext.TIPO_PROFISSIONAL.FirstOrDefault(p => p.ID == id);
        }

        public List<TipoProfissionalModel> BuscarTodos()
        {
            return _bancoContext.TIPO_PROFISSIONAL.ToList();
        }
    }
}
