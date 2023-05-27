using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        private readonly BancoContext _bancoContext;

        public AgendamentoController(BancoContext context)
        {
            _bancoContext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ConsultaModel>>> GetConsultas(int id)
        {
            var consultas = await _bancoContext.CONSULTAS
            .Where(c => c.ID_AGENDAMENTO.ID == id)
            .Select(c => new ConsultaModel
            {
                DATA_START = c.DATA_START,
                DATA_END = c.DATA_END
            })
            .ToListAsync();

            return consultas;

            //var consultas = await _bancoContext.CONSULTAS
            //.Select(c => new ConsultaModel
            //{
            //    DATA_START = c.DATA_START,
            //    DATA_END = c.DATA_END
            //})
            //.ToListAsync();

            //return consultas;
        }

    }
}
