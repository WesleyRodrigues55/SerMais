using Microsoft.AspNetCore.Mvc;
using SerMais.Models;
using SerMais.Repositorio;

namespace SerMais.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly IProfissionalRepositorio _profissionalRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AdministradorController(IProfissionalRepositorio ProfissionalRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _profissionalRepositorio = ProfissionalRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<ProfissionalModel> profissionais = _profissionalRepositorio.BuscarTodos();
            return View(profissionais);
        }

        [HttpPost]
        public IActionResult Aceitar(int modalId)
        {
            //if (ModelState.IsValid)
            //{
            var profissional = _profissionalRepositorio.ObterPorId(modalId);
            var usuario = _usuarioRepositorio.ObterPorId(modalId);
            if (profissional != null)
            {
                profissional.ATIVO = 1;
                usuario.ATIVO = 1;
                _profissionalRepositorio.Atualizar(profissional);
                _usuarioRepositorio.Atualizar(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
            //}
            //else
            //{
            //    return View(model);
            //}
        }

        [HttpPost]
        public IActionResult Recusar(int modalId)
        {
            //if (ModelState.IsValid)
            //{
            var profissional = _profissionalRepositorio.ObterPorId(modalId);
            if (profissional != null)
            {
                profissional.ATIVO = 2;
                _profissionalRepositorio.Atualizar(profissional);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
            //}
            //else
            //{
            //    return View(model);
            //}
        }
    }
}
