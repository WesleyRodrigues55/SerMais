using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public static string slug(string nome)
        {
            string slug = nome.ToLower();
            slug = slug.Replace(" ", "-");

            return slug;
        }

        public void Inserir(UsuarioModel usuario)
        {
            _bancoContext.Entry(usuario).State = EntityState.Added;
            _bancoContext.SaveChanges();
        }

        public void Atualizar(UsuarioModel usuario)
        {
            _bancoContext.Entry(usuario).State = EntityState.Modified;
            _bancoContext.SaveChanges();
        }

        public UsuarioModel ObterPorId(int id)
        {
            return _bancoContext.USUARIO.FirstOrDefault(p => p.ID_PROFISSIONAL.ID == id);
        }

        //public UsuarioModel ValidaLogin(UsuarioModel usuario)
        //{
        //    return _bancoContext.USUARIO.FirstOrDefault(p => p.EMAIL == usuario.EMAIL && p.SENHA == usuario.SENHA);

        //}

        public ProfissionalModel ValidaLogin(UsuarioModel usuario)
        {
            return _bancoContext.USUARIO
                .Join(_bancoContext.PROFISSIONAL, u => u.ID_PROFISSIONAL.ID, p => p.ID, (u, p) => new { Usuario = u, Profissional = p })
                .Where(up => up.Usuario.EMAIL == usuario.EMAIL && up.Usuario.SENHA == usuario.SENHA && up.Usuario.ATIVO == 1)
                .Select(p => new ProfissionalModel
                {
                    ID = p.Profissional.ID,
                    NOME = slug(p.Profissional.NOME),
                    NIVEL = p.Profissional.NIVEL,
                })
                .FirstOrDefault();
        }


    }
}
