using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using SerMais.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using SerMais.Repositorio;
using System.Security.Cryptography;
using SerMais.API;

namespace SerMais.Controllers
{
    public class ProfissionaisController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPortfolioRepositorio _portfolioRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IAgendaProfissionalRepositorio _agendaProfissional;

        public ProfissionaisController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, IPortfolioRepositorio portfolioRepositorio, IUsuarioRepositorio usuarioRepositorio, IAgendaProfissionalRepositorio agendaProfissional)
        {
            hostingEnvironment = environment;
            _portfolioRepositorio = portfolioRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _agendaProfissional = agendaProfissional;
        }

        public IActionResult Index()
        {
            var portfolio = _portfolioRepositorio.BuscarTodos();
            return View(portfolio);
        }

        // aqui virá regras do portfólio do usuário
        // coisas do CRUD
        // e exibição front-end

        [HttpGet("profissionais/portfolio/{id?}/{nome?}")]
        public IActionResult Portfolio([FromRoute] int id, [FromRoute] string nome)
        {
            if (id == 0 || string.IsNullOrEmpty(nome))
                return RedirectToAction("Index", "Error");

            //var checkedSession = _usuarioRepositorio.CheckedSession(id);
            var profissionais = _portfolioRepositorio.BuscaPorIdENome(id);
            var portfolio = new PortfolioModel();

            var viewModel = new PortfolioViewModel
            {
                Profissionais = profissionais,
                Portfolio = portfolio
            };

            return View(viewModel);
        }

        public PortfolioModel checkedFile(PortfolioModel portfolio)
        {
            if (portfolio.IMAGEM != null)
            {
                var uniqueFileName = GetUniqueFileName(portfolio.IMAGEM.FileName);
                var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/img/profiles");
                var filePath = Path.Combine(uploads, uniqueFileName);
                portfolio.IMAGEM.CopyTo(new FileStream(filePath, FileMode.Create));
                portfolio.IMAGEM_PROFILE = uniqueFileName;
            }

            return portfolio;
        }

        private string GetUniqueFileName(string fileName)
        {
            return "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public IActionResult CriarEdicao(PortfolioModel portfolio)
        {
            checkedFile(portfolio);
            _portfolioRepositorio.Salvar(portfolio);

            TempData["MensagemSucesso"] = $"Perfil criado com sucesso!";
            return RedirectToAction("Portfolio", "Profissionais", new { id = portfolio.ID_PROFISSIONAL.ID, nome = portfolio.NOME_PROFISSIONAL });
        }

        public IActionResult SalvarEdicao(PortfolioModel portfolio)
        {
            if (portfolio.IMAGEM == null)
                _portfolioRepositorio.SalvarSemImagem(portfolio);
            else
            {
                checkedFile(portfolio);
                _portfolioRepositorio.SalvarComImagem(portfolio);
            }

            TempData["MensagemSucesso"] = $"Alterações salvas com sucesso!";
            return RedirectToAction("Portfolio", "Profissionais", new { id = portfolio.ID_PROFISSIONAL.ID, nome = portfolio.NOME_PROFISSIONAL });
        }

        public IActionResult CadastroAgenda()
        {
            // Recupera um valor da sessão do usuário
            string username = HttpContext.Session.GetString("username");
            int? id = HttpContext.Session.GetInt32("id");



            if (username == null)
            {
                return RedirectToAction("SemAutorizacao", "Autorizacao");
            }

            var agenda_profissional = _agendaProfissional.BuscarTodos(id);
            var agenda = new AgendaProfissionalModel();
            var viewModel = new AgendaViewModel
            {
                ListaAgendamento = agenda_profissional,
                Agendamento = agenda
            };

            ViewData["id"] = id;
            return View(viewModel);
        }

        public IActionResult CadastrandoHorario(int id_profissional, AgendaProfissionalModel agenda_profissional)
        {
            agenda_profissional.ID_PROFISSIONAL = new ProfissionalModel();
            agenda_profissional.ID_PROFISSIONAL.ID = id_profissional;

            if (Request.Form["dias-semana"] == "nao-repete")
            {
                agenda_profissional.REPETE = "nao-repete";
                _agendaProfissional.CadastroHorarioAgenda(agenda_profissional);
            }
            else
            {
                DateTime dataInicio = DateTime.Parse(agenda_profissional.DIA);
                DateTime dataTermino;

                if (Request.Form["dias-semana"] == "segunda-sexta")
                {
                    agenda_profissional.REPETE = "segunda-sexta";
                    dataTermino = dataInicio.AddDays(4);
                }
                else if (Request.Form["dias-semana"] == "segunda-sabado")
                {
                    agenda_profissional.REPETE = "segunda-sabado";
                    dataTermino = dataInicio.AddDays(5);
                }
                else if (Request.Form["dias-semana"] == "segunda-domingo")
                {
                    agenda_profissional.REPETE = "segunda-domingo";
                    dataTermino = dataInicio.AddDays(6);
                }
                else
                    dataTermino = dataInicio;

                while (dataInicio <= dataTermino)
                {
                    // pode fazer condição para que não insira um horário repetido no mesmo dia
                    //aqui...
                    //...
                    var agenda = new AgendaProfissionalModel
                    {
                        ID_PROFISSIONAL = new ProfissionalModel { ID = id_profissional },
                        DIA = dataInicio.ToString("yyyy/MM/dd"),
                        HORA_START = agenda_profissional.HORA_START,
                        HORA_END = agenda_profissional.HORA_END,
                        REPETE = agenda_profissional.REPETE,
                        ATIVO = agenda_profissional.ATIVO
                    };

                    _agendaProfissional.CadastroHorarioAgenda(agenda);
                    dataInicio = dataInicio.AddDays(1);
                }
            }

            TempData["MensagemSucesso"] = $"Data salva com sucesso!";
            return Redirect("CadastroAgenda");
        }

        public IActionResult DesativarHorario(int modalId)
        {
            TempData["MensagemSucesso"] = $"Horario desativado com sucesso!";
            _agendaProfissional.DesativarPorId(modalId);
            return Redirect("CadastroAgenda");

        }

        [HttpGet("profissionais/consultas/{id?}")]
        public IActionResult Consultas([FromRoute] int id)
        {
            // Recupera um valor da sessão do usuário
            string username = HttpContext.Session.GetString("username");

            if (id == 0)
                return RedirectToAction("Index", "Error");

            if (username == null)
            {
                return RedirectToAction("SemAutorizacao", "Autorizacao");
            }

            ViewData["id"] = id;
            return View();
        }
    }
}
