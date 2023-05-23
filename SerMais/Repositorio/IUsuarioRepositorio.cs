using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Inserir(UsuarioModel usuario);
        void Atualizar(UsuarioModel usuario);
        string UpdateSenha(UsuarioModel usuario);
        string UpdateSenhaLogado(UsuarioModel usuario);
        int ValidarIDEHashAlteracaoSenha(int id, string hash);
        UsuarioModel ObterPorId(int id);
        int ObterPorEmail(string email);
        int ObterIdProfissionalPorIdUsuario(int id);
        string ObterTokenRecuperarSenhaPorId(int id);
        string ObterNomePorIdProfissional(int id);
        ProfissionalModel ValidaLogin(UsuarioModel usuario);
    }
}
