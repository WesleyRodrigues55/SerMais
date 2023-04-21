using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using SerMais.Models;
using SerMais.Repositorio;
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


        // aqui será validado o login
        // assim que clicado, precisa pegar os dados: username e senha
        // - validar com o que tem no banco model: USUARIO
        // - se ok, manter o usuário logado após validação no banco usando: HttpContext.Session.SetString("username", "usuario-que-vem-do-model-validado");
        // - se tudo ok, leva pro dashboard: redirecionando para o controller > método (já tem validação se tem alguém logado ou não)
        // - se der errado, retorna para page login informando o ocorrido (na view login, recebe uma variavel de retorno que expõe uma mensagem ao usuário
        // que indica que usuario ou senha estão incorretos

        [HttpPost]
        public IActionResult ValidaLogin()
        {
            // Armazena um valor na sessão do usuário
            HttpContext.Session.SetString("username", "wesley");

            return RedirectToAction("Index", "Administrador");
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
            //AQUIII
            // ADD NOS REPOSITÍRO ProfissionalRepoisitorio e UsuarioRepositorio os métodos que precisam fazer a
            // INSERÇÃO DOS DADOS e SELEÇÃO DO ID DO PROFISSIONAL INSERIDO (algo como lastId)
            // primeiro ele pega os dados do ProfissionalModel e insere no banco
            // Em seguida ele pega o ID desse profissional que foi inserido e armazena em uma variavel 
            // Após isso ele insere os valores no UsuarioModel (onde ocntém o ID do profissional inserido)


            //Por fim ele move o arquivo file
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
