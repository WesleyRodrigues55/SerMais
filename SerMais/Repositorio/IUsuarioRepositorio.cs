using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Atualizar(UsuarioModel usuario);
        UsuarioModel ObterPorId(int id);
    }
}
