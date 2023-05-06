using Microsoft.EntityFrameworkCore;
using SerMais.Data;
using SerMais.Models;

namespace SerMais.Repositorio
{
    public class PortfolioRepositorio : IPortfolioRepositorio
    {

        private readonly BancoContext _bancoContext;

        public PortfolioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<PortfolioModel> BuscarTodos()
        {
            var result = _bancoContext.PORTFOLIO
                .Join(_bancoContext.PROFISSIONAL,
                    portfolio => portfolio.ID_PROFISSIONAL.ID,
                    profissional => profissional.ID,
                    (portfolio, profissional) => new { Portfolio = portfolio, Profissional = profissional })
                .ToList();

            var portfolios = new List<PortfolioModel>();

            foreach (var item in result)
            {
                portfolios.Add(new PortfolioModel
                {
                    ID = item.Portfolio.ID,
                    IMAGEM_PROFILE = item.Portfolio.IMAGEM_PROFILE,
                    SOBRE = item.Portfolio.SOBRE,
                    ESPECIALIDADE= item.Portfolio.ESPECIALIDADE,
                    VALOR_CONSULTA= item.Portfolio.VALOR_CONSULTA,
                    DURACAO_SESSAO= item.Portfolio.DURACAO_SESSAO,
                    TELEFONE = item.Portfolio.TELEFONE,
                    CELULAR = item.Portfolio.CELULAR,
                    ID_PROFISSIONAL = new ProfissionalModel
                    {
                        ID = item.Profissional.ID,
                        NOME = item.Profissional.NOME,
                        NOME_COMPLETO = item.Profissional.NOME_COMPLETO,
                        CRP = item.Profissional.CRP,
                        CIDADE = item.Profissional.CIDADE
                    }
                });
            }

            return portfolios;
        }

        public List<PortfolioModel> BuscaPorIdENome(int id)
        {
            var result = _bancoContext.PORTFOLIO
                  .Where(portfolio => portfolio.ID_PROFISSIONAL.ID == id)
                  .Join(_bancoContext.PROFISSIONAL,
                  portfolio => portfolio.ID_PROFISSIONAL.ID,
                  profissional => profissional.ID,
                  (portfolio, profissional) => new { Portfolio = portfolio, Profissional = profissional })
                  .ToList();

            var portfolios = new List<PortfolioModel>();

            foreach (var item in result)
            {
                portfolios.Add(new PortfolioModel
                {
                    ID = item.Portfolio.ID,
                    IMAGEM_PROFILE = item.Portfolio.IMAGEM_PROFILE,
                    SOBRE = item.Portfolio.SOBRE,
                    ESPECIALIDADE = item.Portfolio.ESPECIALIDADE,
                    VALOR_CONSULTA = item.Portfolio.VALOR_CONSULTA,
                    DURACAO_SESSAO = item.Portfolio.DURACAO_SESSAO,
                    TELEFONE = item.Portfolio.TELEFONE,
                    CELULAR = item.Portfolio.CELULAR,
                    FORMACAO = item.Portfolio.FORMACAO,
                    ID_PROFISSIONAL = new ProfissionalModel
                    {
                        ID = item.Profissional.ID,
                        NOME = item.Profissional.NOME,
                        NOME_COMPLETO = item.Profissional.NOME_COMPLETO,
                        CRP = item.Profissional.CRP,
                        CIDADE = item.Profissional.CIDADE
                    }
                });
            }

            return portfolios;
        }

    }
}
