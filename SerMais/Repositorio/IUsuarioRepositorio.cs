using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Inserir(UsuarioModel usuario);
        void Atualizar(UsuarioModel usuario);
        UsuarioModel ObterPorId(int id);
    }
}
