using SerMais.Migrations;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IAgendaProfissionalRepositorio
    {
        List<AgendaProfissionalModel> BuscarTodos(int? id);
        AgendaProfissionalModel CadastroHorarioAgenda(AgendaProfissionalModel agenda_profissional);
        void DesativarPorId(int id);
    }
}
