using Microsoft.AspNetCore.Mvc;
using SerMais.Models;
using SerMais.Repositorio;

namespace SerMais.Controllers
{
    public class ProfissionaisController : Controller
    {
        private readonly IPortfolioRepositorio _portfolioRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ProfissionaisController(IPortfolioRepositorio portfolioRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _portfolioRepositorio = portfolioRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
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

        public IActionResult SalvarEdicao(PortfolioModel portfolio)
        {
            if (portfolio.IMAGEM == null)
                _portfolioRepositorio.SalvarSemImagem(portfolio);
            else
                _portfolioRepositorio.Salvar(portfolio);

            TempData["MensagemSucesso"] = $"Alterações salvas com sucesso!";
            return RedirectToAction("Portfolio", "Profissionais", new { id = portfolio.ID_PROFISSIONAL.ID, nome = portfolio.NOME_PROFISSIONAL });
        }
    }
}
