using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        private readonly BancoContext _bancoContext;

        public AgendamentoController(BancoContext context)
        {
            _bancoContext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AgendaProfissionalModel>>> GetConsultas(int id)
        {
            var consultas = await _bancoContext.AGENDA_PROFISSIONAL
            .Where(c => c.ID_PROFISSIONAL.ID == id)
            .Select(c => new AgendaProfissionalModel
            {
                ID = c.ID,
                DIA = c.DIA,
                HORA_START = c.HORA_START,
                HORA_END = c.HORA_END,
                ATIVO = c.ATIVO,
            })
            .ToListAsync();

            return consultas;
        }

        [HttpGet("{id_profissional}")]
        public async Task<ActionResult<List<ConsultaModel>>> GetConsultasProfissional(int id_profissional)
        {
            var consultas = await _bancoContext.AGENDA_PROFISSIONAL
                .Where(c => c.ID_PROFISSIONAL.ID == id_profissional)
                .Join(_bancoContext.CONSULTAS,
                    agenda => agenda.ID,
                    consulta => consulta.ID_AGENDA_PROFISSIONAL.ID,
                    (agenda, consulta) => new { Agenda = agenda, Consulta = consulta })

                .Select(c => new ConsultaModel
                {
                    ID = c.Consulta.ID,
                    QUEIXA = c.Consulta.QUEIXA,
                    ID_AGENDA_PROFISSIONAL = new AgendaProfissionalModel
                    {
                        ID = c.Agenda.ID,
                        HORA_START = c.Agenda.HORA_START,
                        HORA_END = c.Agenda.HORA_END,
                        DIA = c.Agenda.DIA,
                        ATIVO = c.Agenda.ATIVO,
                    },                
                })
                .ToListAsync();

            return consultas;
        }

        [HttpGet("{id_agendamento}")]
        public async Task<ActionResult<List<ConsultaModel>>> GetConsultasPorIdParaOProfissional(int id_agendamento)
        {
            var consultas = await _bancoContext.CONSULTAS
                .Where(c => c.ID == id_agendamento)
                .Join(_bancoContext.AGENDA_PROFISSIONAL,
                    consulta => consulta.ID_AGENDA_PROFISSIONAL.ID,
                    agenda => agenda.ID,
                    (consulta, agenda) => new { Consulta = consulta, Agenda = agenda })
                .Join(_bancoContext.CLIENTE,
                    consultaAgenda => consultaAgenda.Consulta.ID_CLIENTE.ID,
                    cliente => cliente.ID,
                    (consultaAgenda, cliente) => new { ConsultaAgenda = consultaAgenda, Cliente = cliente })
                .Select(c => new ConsultaModel
                {
                    ID = c.ConsultaAgenda.Consulta.ID,
                    QUEIXA = c.ConsultaAgenda.Consulta.QUEIXA,
                    TIPO_REUNIAO = c.ConsultaAgenda.Consulta.TIPO_REUNIAO,
                    ID_AGENDA_PROFISSIONAL = new AgendaProfissionalModel
                    {
                        ID = c.ConsultaAgenda.Agenda.ID,
                        HORA_START = c.ConsultaAgenda.Agenda.HORA_START,
                        HORA_END = c.ConsultaAgenda.Agenda.HORA_END,
                        DIA = c.ConsultaAgenda.Agenda.DIA,
                        ATIVO = c.ConsultaAgenda.Agenda.ATIVO,
                    },
                    ID_CLIENTE = new ClienteModel
                    {
                        ID = c.Cliente.ID,
                        NOME_COMPLETO = c.Cliente.NOME_COMPLETO,
                    },
                })
                .ToListAsync();

            return consultas;
        }


    }
}
