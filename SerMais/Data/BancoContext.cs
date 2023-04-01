using Microsoft.EntityFrameworkCore;
using SerMais.Models;

namespace SerMais.Data
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options): base(options) 
        {
        }
        public DbSet<UsuarioModel> USUARIO { get; set; }
        public DbSet<PessoaModel> PESSOA { get; set; }
    }
}
