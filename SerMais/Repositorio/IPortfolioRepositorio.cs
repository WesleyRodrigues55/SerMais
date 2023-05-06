using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IPortfolioRepositorio
    {
        List<PortfolioModel> BuscarTodos();

        List<PortfolioModel> BuscaPorIdENome(int id);
    }
}
