using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IClienteRepositorio
    {
        int InsereCliente(ClienteModel cliente);
        ClienteModel BuscaEmail(string email);
        int BuscaClientePorEmail(ClienteModel cliente);
    }
}
