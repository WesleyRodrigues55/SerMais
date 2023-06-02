using SerMais.Migrations;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IAgendaProfissionalRepositorio
    {
        List<AgendaProfissionalModel> BuscarTodos(int? id);
        AgendaProfissionalModel CadastroHorarioAgenda(AgendaProfissionalModel agenda_profissional);
        void DesativarPorId(int id);
        AgendaProfissionalModel DadosParaEmail(int id_profissional, int id);
        AgendaProfissionalModel DadosParaEmailProfissional(int id_profissional, int id);
        void CheckedNaConsulta(int id);
    }
}
