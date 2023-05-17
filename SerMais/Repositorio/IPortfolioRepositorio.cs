using SerMais.Models;

namespace SerMais.Repositorio
{
    public interface IPortfolioRepositorio
    {
        PortfolioModel SalvarSemImagem(PortfolioModel portfolio);
        PortfolioModel Salvar(PortfolioModel portfolio);
        List<PortfolioModel> BuscarTodos();
        List<PortfolioModel> BuscaPorIdENome(int id);
    }
}
