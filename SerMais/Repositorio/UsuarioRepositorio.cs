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

        public UsuarioModel CheckedSession(int id)
        {
            return _bancoContext.USUARIO.FirstOrDefault(p => p.ID_PROFISSIONAL.ID == id);
        }

        public string UpdateSenha(UsuarioModel usuario)
        {
            var u = _bancoContext.USUARIO.FirstOrDefault(u => u.ID == usuario.ID);
            u.SENHA = usuario.SENHA;
            u.TOKEN_RECUPERAR_SENHA = usuario.TOKEN_RECUPERAR_SENHA;
            _bancoContext.SaveChanges();
            return u.EMAIL;
        }

        public string UpdateSenhaLogado(UsuarioModel usuario)
        {
            var u = _bancoContext.USUARIO.FirstOrDefault(u => u.ID_PROFISSIONAL.ID == usuario.ID_PROFISSIONAL.ID);
            u.SENHA = usuario.SENHA;
            _bancoContext.SaveChanges();
            return usuario.EMAIL;
        }


        public int ObterPorEmail(string email)
        {
            var usuario = _bancoContext.USUARIO.FirstOrDefault(p => p.EMAIL == email);
            if (usuario == null)
                return -1;
            return usuario.ID;
        }

        public int ObterIdProfissionalPorIdUsuario(int id)
        {
            var idProfissional = _bancoContext.USUARIO
                .Join(_bancoContext.PROFISSIONAL, u => u.ID_PROFISSIONAL.ID, p => p.ID, (u, p) => new { Usuario = u, Profissional = p })
                .Where(up => up.Usuario.ID == id)
                .Select(p => p.Profissional.ID)
                .FirstOrDefault();

            return idProfissional;
        }


        public string ObterNomePorIdProfissional(int id)
        {
            var u = _bancoContext.PROFISSIONAL.FirstOrDefault(u => u.ID == id);
            return u.NOME_COMPLETO;
        }

        public string ObterTokenRecuperarSenhaPorId(int id)
        {
            var usuario = _bancoContext.USUARIO.FirstOrDefault(p => p.ID == id);
            return usuario.TOKEN_RECUPERAR_SENHA;
        }

        public int ValidarIDEHashAlteracaoSenha(int id, string hash)
        {
            var usuario = _bancoContext.USUARIO.FirstOrDefault(u => u.ID == id && u.TOKEN_RECUPERAR_SENHA == hash);
            if (usuario == null)
                return -1;
            return usuario.ID;
        }

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
                    EMAIL = p.Usuario.EMAIL,
                })
                .FirstOrDefault();
        }


    }
}
