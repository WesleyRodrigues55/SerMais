using Microsoft.AspNetCore.Mvc;

namespace SerMais.Controllers
{
    public class TempController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // adicioanr mensagens temporários como forma de propriedades ou métodos? vejo qual é melhor depois
    }
}
