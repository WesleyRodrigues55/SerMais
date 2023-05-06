using Microsoft.AspNetCore.Mvc;
using SerMais.Models;
using SerMais.Repositorio;

namespace SerMais.Controllers
{
    public class ProfissionaisController : Controller
    {
        private readonly IPortfolioRepositorio _portfolioRepositorio;

        public ProfissionaisController(IPortfolioRepositorio portfolioRepositorio)
        {
            _portfolioRepositorio = portfolioRepositorio;
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
            {
                return RedirectToAction("Index", "Error");
            }

            var profissionais = _portfolioRepositorio.BuscaPorIdENome(id);

            return View(profissionais);
        }
    }
}
