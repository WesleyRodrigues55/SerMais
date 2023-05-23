using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SerMais.Repositorio;

namespace SerMais.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static string SubjectAcceptedEmail(string nome)
        {
            string assunto = $"Parabéns {nome} você foi aprovado na plataforma SerMais!";
            return assunto;
        }
        public static string SubjectDeclinedEmail(string nome)
        {
            string assunto = $"Desculpe {nome} você não foi aprovado na plataforma SerMais!";
            return assunto;
        }

        public static string SubjectCreateAccount(string nome)
        {
            string assunto = $"Parabéns {nome} você acabou de criar uma conta na plataforma SerMais!";
            return assunto;
        }

        public static string SubjectRetrieveAccount()
        {
            string assunto = $"SerMais - Recuperação de senha";
            return assunto;
        }
        public static string SubjectRetrievePasswordAccount()
        {
            string assunto = $"SerMais - Sua senha acabou de ser alterada";
            return assunto;
        }

        public static string ContentAcceptedEmail(string nome)
        {
            string content =
                $"<h1>Parabéns {nome} você foi aprovado em nossa plataforma!</h1>" +
                $"<p>Clique <a href='https://localhost:7235/Login' target='_blank'>aqui</a> para fazer login em sua conta.</p>" +
                $"<hr>" +
                $"<p>caso tenha esquecido seus dados de login, clique <a href='https://localhost:7235/Login/EsqueceuSenha' target='_blank'>aqui</a> e recupere sua senha.</p>" +
                $"<hr>" +
                $"<p>A SerMais agradeçe pela sua preferência e paciência.</p>" +
                $"<hr>" +
                $"<p>Siga nossos canais de atendimento e nossas redes sociais abaixo:</p>";
            return content;
        }
        public static string ContentDeclinedEmail(string nome)
        {
            string content =
                $"<h1>Desculpe {nome} você não foi aprovado em nossa plataforma!</h1>" +
                $"<p>Mas não fique triste, poderá voltar aqui futuramente e tentar a aprovação de novo.</p>" +
                $"<hr>" +
                $"<p>A SerMais agradece por sua colaboração.</p>" +
                $"<hr>" +
                $"<p>Siga nossos canais de atendimento e nossas redes sociais abaixo:</p>";
            return content;
        }

        public static string ContentCreateAccount(string nome)
        {
            string content =
                $"<h1>Parabéns {nome} você acabou de criar uma conta na plataforma SerMais!</h1>" +
                $"<p>Em breve enviaremos um e-mail para você confirmando sua aprovação na plataforma, aguarde..." +
                $"<hr>" +
                $"<p>A SerMais agradeçe pela sua preferência e paciência.</p>" +
                $"<hr>" +
                $"<p>Siga nossos canais de atendimento e nossas redes sociais abaixo:</p>";
            return content;
        }
        public static string ContentRetrieveAccount(string nome, int id, string token)
        {
            string content =
                $"<h1>Olá, <br> {nome} você solicitou a recuperação de senha de acesso ao sistema SerMais.</h1>" +
                $"<p>Clique no link abaixo para cadastrar a nova senha:" +
                $"<a href='https://localhost:7235/Login/RecuperarSenha/{id}/{token}' target='_blank'>https://localhost:7235/Login/RecuperarSenha/{id}/{token}</a></p>" +
                $"<hr>" +
                $"<p>Caso seu cliente de e-mail não permita clicar no link acima, copie e cole o endereço abaixo em seu navegador " +
                $"<a href='https://localhost:7235/Login/RecuperarSenha/{id}/{token}' target='_blank'>https://localhost:7235/Login/RecuperarSenha/{id}/{token}</a></p>" +
                $"<hr>" +
                $"<p>Siga nossos canais de atendimento e nossas redes sociais abaixo:</p>";
            return content;
        }

        public static string ContentRetrievePasswordAccount()
        {
            string content =
                $"<h1>Alteração de senha.</h1>" +
                $"<p>Sua senha acabou de ser alterada, se foi você, clique no link para fazer login: " +
                $"<a href='https://localhost:7235/Login/index' target='_blank'>https://localhost:7235/Login/Index</a></p>" +
                $"<hr>" +
                $"<p>Caso não tenha sido você, entre em contato conosco, pelo e-mail: " +
                $"sermaissuporte@gmail.com</p>" +
                $"<hr>" +
                $"<p>Siga nossos canais de atendimento e nossas redes sociais abaixo:</p>";
            return content;
        }

        public static MimeMessage ContentMessageEmail(string nome, string email, string assunto, string content)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SerMais", "sermais.software@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = assunto;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = content;
            message.Body = bodyBuilder.ToMessageBody();

            return message;
        }

        public static void Smtp(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("sermais.software@gmail.com", "vfbztcwwwoedeeof");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static string SendAccepted(int id, IProfissionalRepositorio _profissionalRepositorio)
        {
            var profissional = _profissionalRepositorio.BuscarEmailPorID(id);
            var subject = SubjectAcceptedEmail(profissional.NOME);
            var content = ContentAcceptedEmail(profissional.NOME);
            var message = ContentMessageEmail(profissional.NOME, profissional.EMAIL, subject, content);
            Smtp(message);

            return "Email enviado com sucesso!";
        }

        public static string SendDeclined(int id, IProfissionalRepositorio _profissionalRepositorio)
        {
            var profissional = _profissionalRepositorio.BuscarEmailPorID(id);
            var subject = SubjectDeclinedEmail(profissional.NOME);
            var content = ContentDeclinedEmail(profissional.NOME);
            var message = ContentMessageEmail(profissional.NOME, profissional.EMAIL, subject, content);
            Smtp(message);

            return "Email enviado com sucesso!";
        }

        public static string SendCreateAccount(string email, string nome)
        {
            var subject = SubjectCreateAccount(nome);
            var content = ContentCreateAccount(nome);
            var message = ContentMessageEmail(nome, email, subject, content);
            Smtp(message);

            return "Email enviado com sucesso!";
        }

        public static string SendRetrieveAccount(string email, string nome, int id_usuario, string token)
        {
            var subject = SubjectRetrieveAccount();
            var content = ContentRetrieveAccount(nome, id_usuario, token);
            var message = ContentMessageEmail(nome, email, subject, content);
            Smtp(message);

            return "Email enviado com sucesso!";
        }
        public static string SendRetrievePasswordAccount(string email)
        {
            var subject = SubjectRetrievePasswordAccount();
            var content = ContentRetrievePasswordAccount();
            var message = ContentMessageEmail("", email, subject, content);
            Smtp(message);

            return "Email enviado com sucesso!";
        }

    }
}
