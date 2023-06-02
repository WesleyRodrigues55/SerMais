using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel BuscaEmail(string email)
        {
            return _bancoContext.CLIENTE
                .FirstOrDefault(c => c.EMAIL == email);
        }

        public int BuscaClientePorEmail(ClienteModel cliente)
        {
            var clienteEncontrado = _bancoContext.CLIENTE
                .FirstOrDefault(c=> c.EMAIL == cliente.EMAIL);

            if (clienteEncontrado != null)
            {
                return clienteEncontrado.ID;
            }
            else
            {
                return -1;
            }
        }

        public int InsereCliente(ClienteModel cliente)
        {
            _bancoContext.Entry(cliente).State = EntityState.Added;
            _bancoContext.SaveChanges();

            return cliente.ID;
        }
    }
}
