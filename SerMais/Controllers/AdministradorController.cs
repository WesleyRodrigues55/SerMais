using Microsoft.AspNetCore.Mvc;
using SerMais.Models;
using SerMais.Repositorio;

namespace SerMais.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly IProfissionalRepositorio _profissionalRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITipoProfissionalRepositorio _tipoProfissionalRepositorio;

        public AdministradorController(IProfissionalRepositorio ProfissionalRepositorio, IUsuarioRepositorio usuarioRepositorio, ITipoProfissionalRepositorio tipoProfissionalRepositorio)
        {
            _profissionalRepositorio = ProfissionalRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _tipoProfissionalRepositorio = tipoProfissionalRepositorio;
        }

        public IActionResult Index()
        {
            // Recupera um valor da sessão do usuário
            string username = HttpContext.Session.GetString("username");

            if (username == null)
            {
                return RedirectToAction("SemAutorizacao", "Autorizacao");
            }

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

        //TIPO PROFISSIONAL

        //FALTA O CADASTRAR

        public IActionResult TipoProfissional()
        {
            List<TipoProfissionalModel> tipo_profissionais = _tipoProfissionalRepositorio.BuscarTodos();
            return View(tipo_profissionais);
        }

        public IActionResult AtivarTipoProfissional(int modalId)
        {
            var tipo_profissional = _tipoProfissionalRepositorio.ObterPorId(modalId);
            if (tipo_profissional != null)
            {
                tipo_profissional.ATIVO = 1;
                _tipoProfissionalRepositorio.Atualizar(tipo_profissional);
                return RedirectToAction("TipoProfissional", "Administrador");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult DesativarTipoProfissional(int modalId)
        {
            var tipo_profissional = _tipoProfissionalRepositorio.ObterPorId(modalId);
            if (tipo_profissional != null)
            {
                tipo_profissional.ATIVO = 0;
                _tipoProfissionalRepositorio.Atualizar(tipo_profissional);
                return RedirectToAction("TipoProfissional", "Administrador");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
