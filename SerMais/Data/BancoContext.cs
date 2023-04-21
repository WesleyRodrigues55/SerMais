using Microsoft.EntityFrameworkCore;
using SerMais.Models;

namespace SerMais.Data
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options): base(options) 
        {
        }

        public DbSet<ProfissionalModel> PROFISSIONAL { get; set; }
        public DbSet<UsuarioModel> USUARIO { get; set; }

        //public DbSet<PortfolioModel> PORTFOLIO { get; set; }

        public DbSet<ClienteModel> CLIENTE { get; set; }
        public DbSet<AgendamentoModel> AGENDAMENTO { get; set;}
        public DbSet<ConsultaModel> CONSULTA { get; set; }
        public DbSet<TipoConsultaModel> TIPO_CONSULTA_MODEL { get; set; }

    }
}
