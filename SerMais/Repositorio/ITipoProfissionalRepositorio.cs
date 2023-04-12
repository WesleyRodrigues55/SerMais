using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface ITipoProfissionalRepositorio
    {
        void Atualizar(TipoProfissionalModel tipo_profissional);
        TipoProfissionalModel ObterPorId(int id);
        List<TipoProfissionalModel> BuscarTodos();
    }
}
