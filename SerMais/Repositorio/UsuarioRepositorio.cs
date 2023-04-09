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
        public void Atualizar(UsuarioModel usuario)
        {
            _bancoContext.Entry(usuario).State = EntityState.Modified;
            _bancoContext.SaveChanges();
        }
        public UsuarioModel ObterPorId(int id)
        {
            return _bancoContext.USUARIO.FirstOrDefault(p => p.ID_PROFISSIONAL.ID == id);
        }
    }
}
