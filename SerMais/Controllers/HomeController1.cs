using Microsoft.AspNetCore.Mvc;

namespace SerMais.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
