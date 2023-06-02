using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IAgendamentoRepositorio
    {
        List<AgendaProfissionalModel> BuscarPorIdeDia(int id_profissional, string dia);
    }
}
