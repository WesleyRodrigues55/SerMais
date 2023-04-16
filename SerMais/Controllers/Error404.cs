using Microsoft.AspNetCore.Mvc;

namespace SerMais.Controllers
{
    public class Error404 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
