using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IProfissionalRepositorio
    {
        void Atualizar(ProfissionalModel profissional);
        ProfissionalModel ObterPorId(int id);
        List<ProfissionalModel> BuscarTodos();

    }
}
