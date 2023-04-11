using Microsoft.AspNetCore.Mvc;

namespace SerMais.Controllers
{
    public class AutorizacaoController : Controller
    {
        // página sem autorizacao, será adicionado uma view mais formal e informativa
        public IActionResult SemAutorizacao()
        {
            return View();
        }

        // ação de logout que terá na Partial _Navegacao e em outros lugares
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
