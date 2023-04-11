using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using SerMais.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SerMais.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public LoginController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar(ProfissionalModel profissional, UsuarioModel usuario)
        {
            var viewModel = new ViewProfissionalUsuarioModel
            {
                Profissional = profissional,
                Usuario = usuario
            };

            return View(viewModel);
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(ProfissionalModel profissional, UsuarioModel usuario)
        {
            if (profissional.FILE != null)
            {
                var uniqueFileName = GetUniqueFileName(profissional.FILE.FileName);
                var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                profissional.FILE.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            return RedirectToAction("Index", "Login");
        }

        private string GetUniqueFileName(string fileName)
        {
            //fileName = Path.GetFileName(fileName);
            //return Path.GetFileNameWithoutExtension(fileName)
            //          + "_"
            //          + Guid.NewGuid().ToString().Substring(0, 4)
            //          + Path.GetExtension(fileName);
            return    "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public IActionResult EsqueceuSenha()
        {
            return View();
        }

    }
}
