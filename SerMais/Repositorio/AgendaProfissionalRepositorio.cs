using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class AgendaProfissionalRepositorio : IAgendaProfissionalRepositorio
    {
        private readonly BancoContext _bancoContext;

        public AgendaProfissionalRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AgendaProfissionalModel CadastroHorarioAgenda(AgendaProfissionalModel agenda)
        {
            _bancoContext.Entry(agenda).State = EntityState.Added;
            _bancoContext.SaveChanges();

            return agenda;
        }

        public void DesativarPorId(int id)
        {
            var item = _bancoContext.AGENDA_PROFISSIONAL.Find(id);
            if (item != null)
            {
                item.ATIVO = 0;
                _bancoContext.SaveChanges();
            }
        }

        public List<AgendaProfissionalModel> BuscarTodos(int? id)
        {
            var result = _bancoContext.AGENDA_PROFISSIONAL
                .Where(ap => ap.ID_PROFISSIONAL.ID == id && ap.ATIVO == 1)
                .Join(_bancoContext.PROFISSIONAL,
                    agendamento => agendamento.ID_PROFISSIONAL.ID,
                    profissional => profissional.ID,
                    (agendamento, profissional) => new { Agendamento = agendamento, Profissional = profissional })
                .ToList();

            var agendamentos = new List<AgendaProfissionalModel>();

            foreach (var item in result)
            {
                agendamentos.Add(new AgendaProfissionalModel
                {
                    ID = item.Agendamento.ID,
                    DIA = item.Agendamento.DIA,
                    HORA_START = item.Agendamento.HORA_START,
                    HORA_END = item.Agendamento.HORA_END,
                    ID_PROFISSIONAL = new ProfissionalModel
                    {
                        ID = item.Profissional.ID
                    }
                });
            }
            return agendamentos;
        }


    }
}
