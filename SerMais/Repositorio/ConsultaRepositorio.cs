using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ConsultaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ConsultaModel InsereConsulta(ConsultaModel consulta)
        {
            _bancoContext.Entry(consulta).State = EntityState.Added;
            _bancoContext.SaveChanges();

            return consulta;
        }


    }
}
