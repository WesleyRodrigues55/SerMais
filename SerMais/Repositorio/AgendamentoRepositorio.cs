using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public AgendamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<AgendaProfissionalModel> BuscarPorIdeDia(int id_profissional, string dia)
        {
            var result = _bancoContext.AGENDA_PROFISSIONAL
                .Where(ap => ap.DIA == dia && ap.ID_PROFISSIONAL.ID == id_profissional && ap.ATIVO == 1)
                .Select(ap => new AgendaProfissionalModel
                {
                    ID = ap.ID,
                    DIA= ap.DIA,
                    HORA_START = ap.HORA_START,
                    HORA_END = ap.HORA_END
                })
                .ToList();

            return result;
        }


    }
}
