using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly BancoContext _bancoContext;
   
        public ProfissionalRepositorio(BancoContext bancoContext)
         {
             _bancoContext = bancoContext;
         }
        public void Atualizar(ProfissionalModel profissional)
        {
            _bancoContext.Entry(profissional).State = EntityState.Modified;
            _bancoContext.SaveChanges();
        }
        public ProfissionalModel ObterPorId(int id)
        {
            return _bancoContext.PROFISSIONAL.FirstOrDefault(p => p.ID == id);
        }
        public List<ProfissionalModel> BuscarTodos()
        {
            return _bancoContext.PROFISSIONAL
                .Where(p => p.ATIVO == 0)
                .ToList();
        }
    }
}
