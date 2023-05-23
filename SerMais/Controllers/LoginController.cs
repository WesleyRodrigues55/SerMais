using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using SerMais.Models;
using SerMais.Repositorio;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Security.Cryptography;

namespace SerMais.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IProfissionalRepositorio _profissionalRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, IProfissionalRepositorio profissionalRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            hostingEnvironment = environment;
            _profissionalRepositorio = profissionalRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index(UsuarioModel usuario)
        {
            return View(usuario);
        }


        [HttpPost]
        public IActionResult ValidaLogin(UsuarioModel usuario)
        {
            usuario.SENHA = criptografarSenha(usuario.SENHA);
            var checked_usuario = _usuarioRepositorio.ValidaLogin(usuario);
            if (checked_usuario != null)
            {
                HttpContext.Session.SetString("username", checked_usuario.NOME);
                HttpContext.Session.SetInt32("nivel", checked_usuario.NIVEL);
                HttpContext.Session.SetInt32("id", checked_usuario.ID);

                if (checked_usuario.NIVEL == 1)
                {
                    return RedirectToAction("Portfolio", "Profissionais", new { id = checked_usuario.ID, nome = checked_usuario.NOME });

                } else if (checked_usuario.NIVEL == 2)
                {
                    return RedirectToAction("Index", "Administrador");
                }
            }
            TempData["MensagemErroCredenciais"] = $"Suas credenciais estão incorretas, ou ainda você não foi aprovado em nossa plataforma.";
            return RedirectToAction("Index", "Login");
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

        public ProfissionalModel checkedFile(ProfissionalModel profissional)
        {
            if (profissional.FILE != null)
            {
                var uniqueFileName = GetUniqueFileName(profissional.FILE.FileName);
                var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "uploads/curriculos");
                var filePath = Path.Combine(uploads, uniqueFileName);
                profissional.FILE.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return profissional;
        }

        public static string criptografarSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hash = sha256.ComputeHash(bytes);
                string senhaCriptografada = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return senhaCriptografada;
            }
        }

        public static string RandomToken()
        {
            byte[] tokenBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenBytes);
            }

            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(tokenBytes);
                string randomToken = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return randomToken;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(ProfissionalModel profissional, UsuarioModel usuario)
        {
            profissional.NOME_COMPLETO = profissional.NOME + " " + profissional.SOBRENOME;
            if (_profissionalRepositorio.BuscaCrp(profissional.CRP) == null)
            {
                var profissionalInserido = _profissionalRepositorio.Inserir(profissional);
                usuario.ID_PROFISSIONAL = profissionalInserido;
                usuario.SENHA = criptografarSenha(usuario.SENHA);
                usuario.TOKEN_RECUPERAR_SENHA = RandomToken();
                _usuarioRepositorio.Inserir(usuario);
                checkedFile(profissional);
                EmailController.SendCreateAccount(profissional.EMAIL, profissional.NOME);
                TempData["MensagemSucesso"] = $"Cadastro realizado com sucesso, te enviaremos um e-mail com mais detalhes sobre o procedimento.";
                return RedirectToAction("Registrar", "Login");
            }
            TempData["MensagemUsuarioExiste"] = $"Esse usuário já existe";
            return RedirectToAction("Registrar", "Login");
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

        public IActionResult EsqueceuSenha(UsuarioModel usuario)
        {
            return View(usuario);
        }

        public IActionResult ActionEsqueciSenha(UsuarioModel usuario)
        {
            var id_usuario = _usuarioRepositorio.ObterPorEmail(usuario.EMAIL);
            if (id_usuario == -1)
            {
                TempData["EmailNaoEncontrado"] = $"E-mail não encontrado em nossa base de dados, verifique se o e-mail foi digitado corretamente.";
                return Redirect("EsqueceuSenha");
            }
            var id_profissional = _usuarioRepositorio.ObterIdProfissionalPorIdUsuario(id_usuario);

            var token_recuperar = _usuarioRepositorio.ObterTokenRecuperarSenhaPorId(id_usuario);
            var nome = _usuarioRepositorio.ObterNomePorIdProfissional(id_profissional);
            EmailController.SendRetrieveAccount(usuario.EMAIL, nome, id_usuario, token_recuperar);
            TempData["MensagemEnviada"] = $"Enviamos um e-mail para {usuario.EMAIL}, verifiquei sua caixa de mensagens!";
            return Redirect("EsqueceuSenha");
        }

        [HttpGet("login/recuperarSenha/{id?}/{hash?}")]
        public IActionResult RecuperarSenha([FromRoute] int id, [FromRoute] string hash, UsuarioModel usuario)
        {
            if (id == 0 || string.IsNullOrEmpty(hash))
                return RedirectToAction("Index", "Error");

            var u = _usuarioRepositorio.ValidarIDEHashAlteracaoSenha(id, hash);
            if (u == -1)
                return RedirectToAction("Index", "Error");

            ViewData["Id"] = id;
            ViewData["Hash"] = hash;
            return View(usuario);
        }

        public IActionResult SenhaAlterada()
        {
            ViewData["SenhaAlterada"] = $"Sua senha foi alterada, enviamos um e-mail para você";
            return View();
        }

        public IActionResult RecuperandoSenha(UsuarioModel usuario)
        {
            usuario.TOKEN_RECUPERAR_SENHA = RandomToken();
            usuario.SENHA = criptografarSenha(usuario.SENHA);
            usuario.SENHA_REPETE = criptografarSenha(usuario.SENHA);
            var u = _usuarioRepositorio.UpdateSenha(usuario);
            EmailController.SendRetrievePasswordAccount(u);
            return Redirect("SenhaAlterada");
        }


        // LOGADO
        public IActionResult AlterarSenhaLogado(UsuarioModel usuario)
        {
            return View(usuario);
        }

        public IActionResult AlterandoSenhaLogado(UsuarioModel usuario)
        {
            if (usuario.SENHA == null)
                return RedirectToAction("Index", "Error");
            usuario.SENHA = criptografarSenha(usuario.SENHA);
            usuario.SENHA_REPETE = criptografarSenha(usuario.SENHA);
            var u = _usuarioRepositorio.UpdateSenhaLogado(usuario);
            EmailController.SendRetrievePasswordAccount(u);
            HttpContext.Session.Clear();
            return Redirect("SenhaAlterada");
        }

    }
}
