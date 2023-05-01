using Microsoft.AspNetCore.Mvc;
using SerMais.Models;

namespace SerMais.Controllers
{
    public class ProfissionaisController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

            var model = new ProfissionalModel
            {
                ID = id,
                NOME = nome
            };
            return View(model);
        }
    }
}
