using Microsoft.AspNetCore.Mvc;

namespace SerMais.Controllers
{
    public class PortfolioController : Controller
    {

        // aqui virá regras do portfólio do usuário
        // coisas do CRUD
        // e exibição front-end
        public IActionResult Index()
        {
            return View();
        }
    }
}
