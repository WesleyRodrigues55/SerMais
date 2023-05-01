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

        public static MimeMessage ContentMessageEmail(string nome, string email, string assunto, string content)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SerMais", "sermais.software@gmail.com"));
            message.To.Add(new MailboxAddress(nome, email));
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
    }
}
