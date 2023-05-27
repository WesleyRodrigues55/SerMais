using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Repositorio;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace SerMais
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionado para que a Partial _Navegacao tenha acesso aos contextos de Session (Não é usual), mas foi necessário nesse caso
            builder.Services.AddHttpContextAccessor();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //conexão com o banco
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddScoped<IProfissionalRepositorio, ProfissionalRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IPortfolioRepositorio, PortfolioRepositorio>();
            builder.Services.AddScoped<IAgendaProfissionalRepositorio, AgendaProfissionalRepositorio>();

            // Cors API
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });

            // Configurando a sessão
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            app.UseCors();

            // Usando a sessão
            app.UseSession();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Profissionais}/{action=Portfolio}/{id?}/{nome?}");

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Login}/{action=RecuperarSenha}/{id?}/{hash?}");

            app.MapControllerRoute(
                name: "API Default",
                pattern: "api/{controller=Agendamento}/{id?}");

            app.Run();
        }
    }
}