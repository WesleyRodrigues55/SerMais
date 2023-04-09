using Microsoft.AspNetCore.Mvc;

namespace SerMais.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult EsqueceuSenha()
        {
            return View();
        }

    }
}
