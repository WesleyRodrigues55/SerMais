using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
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
            // Recupera um valor da sessão do usuário
            string username = HttpContext.Session.GetString("username");

            if (username == null)
            {
                return RedirectToAction("SemAutorizacao", "Autorizacao");
            }
            return View();
        }

        public IActionResult ProfissionaisPendentes()
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
        public IActionResult AceitarProfissional(int modalId, string modalNome)
        {
            if (ModelState.IsValid)
            {
                var profissional = _profissionalRepositorio.ObterPorId(modalId);
                var usuario = _usuarioRepositorio.ObterPorId(modalId);
                if (profissional != null)
                {
                    profissional.ATIVO = 1;
                    usuario.ATIVO = 1;
                    _profissionalRepositorio.AtualizaAtivoProfissional(profissional);
                    _usuarioRepositorio.Atualizar(usuario);
                    EmailController.SendAccepted(modalId, _profissionalRepositorio);
                    TempData["MensagemAceita"] = $"Profissional {modalNome} aceito com sucesso";
                    return RedirectToAction("ProfissionaisPendentes");
                }
                else
                {
                    TempData["MensagemErro"] = $"Houve algum erro durante o procedimento, tente novamente.";
                    return RedirectToAction("ProfissionaisPendentes");
                }
            }
            else
            {
                TempData["MensagemErro"] = $"Houve algum erro durante o procedimento, tente novamente.";
                return RedirectToAction("ProfissionaisPendentes");
            }
        }

        [HttpPost]
        public IActionResult RecusarProfissional(int modalId, string modalNome)
        {
            if (ModelState.IsValid)
            {
                var profissional = _profissionalRepositorio.ObterPorId(modalId);
                if (profissional != null)
                {
                    profissional.ATIVO = 2;
                    _profissionalRepositorio.AtualizaAtivoProfissional(profissional);
                    EmailController.SendDeclined(modalId, _profissionalRepositorio);
                    TempData["MensagemRecusada"] = $"Profissional {modalNome} recusada com sucesso";
                    return RedirectToAction("ProfissionaisPendentes");
                }
                else
                {
                    TempData["MensagemErro"] = $"Houve algum erro durante o procedimento, tente novamente.";
                    return RedirectToAction("ProfissionaisPendentes");
                }
            }
            else
            {
                TempData["MensagemErro"] = $"Houve algum erro durante o procedimento, tente novamente.";
                return RedirectToAction("ProfissionaisPendentes");
            }
        }
        
    }
}
