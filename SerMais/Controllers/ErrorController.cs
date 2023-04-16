using Microsoft.AspNetCore.Mvc;

namespace SerMais.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
