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


        // aqui será validado o login
        // assim que clicado, precisa pegar os dados: username e senha
        // - validar com o que tem no banco model: USUARIO
        // - se ok, manter o usuário logado após validação no banco usando: HttpContext.Session.SetString("username", "usuario-que-vem-do-model-validado");
        // - se tudo ok, leva pro dashboard: redirecionando para o controller > método (já tem validação se tem alguém logado ou não)
        // - se der errado, retorna para page login informando o ocorrido (na view login, recebe uma variavel de retorno que expõe uma mensagem ao usuário
        // que indica que usuario ou senha estão incorretos

        [HttpPost]
        public IActionResult ValidaLogin(UsuarioModel usuario)
        {
            usuario.SENHA = criptografarSenha(usuario.SENHA);
            var checked_usuario = _usuarioRepositorio.ValidaLogin(usuario);
            if (checked_usuario != null)
            {
                // Armazena um valor na sessão do usuário
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

        public IActionResult RecuperarSenha()
        {
            return View();
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

        [HttpPost]
        public IActionResult Cadastrar(ProfissionalModel profissional, UsuarioModel usuario)
        {
            profissional.NOME_COMPLETO = profissional.NOME + " " + profissional.SOBRENOME;
            if (_profissionalRepositorio.BuscaCrp(profissional.CRP) == null)
            {
                var profissionalInserido = _profissionalRepositorio.Inserir(profissional);
                usuario.ID_PROFISSIONAL = profissionalInserido;
                usuario.SENHA = criptografarSenha(usuario.SENHA);
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

        public IActionResult EsqueceuSenha()
        {
            return View();
        }

    }
}
