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
        public void AtualizaAtivoProfissional(ProfissionalModel profissional)
        {
            _bancoContext.Entry(profissional).State = EntityState.Modified;
            _bancoContext.SaveChanges();
        }

        public ProfissionalModel Inserir(ProfissionalModel profissional)
        {
            _bancoContext.Entry(profissional).State = EntityState.Added;
            _bancoContext.SaveChanges();

            return profissional;
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

        public ProfissionalModel BuscarEmailPorID(int id)
        {
            var profissional = _bancoContext.PROFISSIONAL
                .FirstOrDefault(p => p.ID == id);

            if (profissional != null)
            {
                return new ProfissionalModel
                {
                    EMAIL = profissional.EMAIL,
                    NOME = profissional.NOME
                };
            }

            return null;

            //return profissional?.EMAIL;
        }

        public ProfissionalModel BuscaCrp(string crp)
        {
            return _bancoContext.PROFISSIONAL
                .FirstOrDefault(p => p.CRP == crp);
        }
    }
}
