using Microsoft.AspNetCore.Mvc;
using SerMais.Migrations;
using SerMais.Models;
using SerMais.Repositorio;
using System.Globalization;

namespace SerMais.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IPortfolioRepositorio _portfolioRepositorio;
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly IConsultaRepositorio _consultaRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IAgendaProfissionalRepositorio _agendaProfissionalRepositorio;

        public ClienteController(IAgendamentoRepositorio agendamento, IPortfolioRepositorio portfolio, IConsultaRepositorio consulta, IClienteRepositorio cliente, IAgendaProfissionalRepositorio agendaProfissional)
        {
            _agendamentoRepositorio = agendamento;
            _portfolioRepositorio = portfolio;
            _consultaRepositorio = consulta;
            _clienteRepositorio = cliente;
            _agendaProfissionalRepositorio = agendaProfissional;
        }

        [HttpGet("cliente/agendamento/{id?}")]
        public IActionResult Agendamento([FromRoute] int id)
        {
            if (id == 0)
                return RedirectToAction("Index", "Error");

            var portfolio = _portfolioRepositorio.BuscaPorIdENome(id);
            var cliente = new ClienteModel();
            var consulta = new ConsultaModel();
            var viewModel = new AgendaClienteViewModel
            {
                Portfolios = portfolio,
                Cliente = cliente,
                Consulta = consulta
            };

            ViewData["id"] = id;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BuscarHorariosDisponiveis(int id_profissional, string dia)
        {
            var horarios = _agendamentoRepositorio.BuscarPorIdeDia(id_profissional, dia);
            return PartialView("_HorariosDisponiveisPartial", horarios);
        }

        public string TipoReuniao(ConsultaModel consulta)
        {
            if (Request.Form["tipo-reuniao"] == "presencial")
                consulta.TIPO_REUNIAO = "PRESENCIAL";
            else if (Request.Form["tipo-reuniao"] == "online")
                consulta.TIPO_REUNIAO = "ONLINE";

            return consulta.TIPO_REUNIAO;
        }

        [HttpPost]
        public IActionResult AgendarConsulta(int id_profissional, int id_agenda_profissional, ClienteModel cliente, ConsultaModel consulta)
        {
            if (_clienteRepositorio.BuscaEmail(cliente.EMAIL) == null)
            {
                int id_cliente = _clienteRepositorio.InsereCliente(cliente);
                TipoReuniao(consulta);
                consulta.ID_CLIENTE = new ClienteModel();
                consulta.ID_AGENDA_PROFISSIONAL = new AgendaProfissionalModel();
                consulta.ID_CLIENTE.ID = id_cliente;
                consulta.ID_AGENDA_PROFISSIONAL.ID = id_agenda_profissional;
                var c = _consultaRepositorio.InsereConsulta(consulta);
                _agendaProfissionalRepositorio.CheckedNaConsulta(id_agenda_profissional);
                var profissional_agendamento = _agendaProfissionalRepositorio.DadosParaEmail(id_profissional, id_agenda_profissional);
                var email_profissional = _agendaProfissionalRepositorio.DadosParaEmailProfissional(id_profissional, id_agenda_profissional);
                EmailController.SendCreateConsultAccount(cliente.EMAIL, profissional_agendamento);
                EmailController.SendCreateConsultProfissionalAccount(email_profissional, cliente);
                TempData["MensagemSucesso"] = $"Parabéns! você acabou de realizar um agendamento, te enviamos uma e-mail com mais informações.";
                return RedirectToAction("Agendamento", "Cliente", new { id = id_profissional });
            }

            TempData["MensagemClienteExiste"] = $"O E-mail informado já existe em nossa base de dados";
            return RedirectToAction("Agendamento", "Cliente", new { id = id_profissional });
        }

        [HttpPost]
        public IActionResult AgendarConsultaEmailExistente(int id_profissional, int id_agenda_profissional, ClienteModel cliente, ConsultaModel consulta)
        {
            int id_cliente = _clienteRepositorio.BuscaClientePorEmail(cliente);
            TipoReuniao(consulta);
            consulta.ID_CLIENTE = new ClienteModel();
            consulta.ID_AGENDA_PROFISSIONAL = new AgendaProfissionalModel();
            consulta.ID_CLIENTE.ID = id_cliente;
            consulta.ID_AGENDA_PROFISSIONAL.ID = id_agenda_profissional;
            var c = _consultaRepositorio.InsereConsulta(consulta);
            _agendaProfissionalRepositorio.CheckedNaConsulta(id_agenda_profissional);
            var profissional_agendamento = _agendaProfissionalRepositorio.DadosParaEmail(id_profissional, id_agenda_profissional);
            var email_profissional = _agendaProfissionalRepositorio.DadosParaEmailProfissional(id_profissional, id_agenda_profissional);
            EmailController.SendCreateConsultAccount(cliente.EMAIL, profissional_agendamento);
            EmailController.SendCreateConsultProfissionalAccount(email_profissional, cliente);
            TempData["MensagemSucesso"] = $"Parabéns! você acabou de realizar um agendamento, te enviamos um e-mail com mais informações.";
            return RedirectToAction("Agendamento", "Cliente", new { id = id_profissional });
        }
    }
}
