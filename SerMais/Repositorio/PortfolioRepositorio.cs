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

        public static string slug(string nome)
        {
            string slug = nome.ToLower();
            slug = slug.Replace(" ", "-");

            return slug;
        }

        public PortfolioModel SalvarSemImagem(PortfolioModel portfolio)
        {
            var p = _bancoContext.PORTFOLIO.FirstOrDefault(p => p.ID_PROFISSIONAL == portfolio.ID_PROFISSIONAL);
            p.ESPECIALIDADE = portfolio.ESPECIALIDADE;
            p.VALOR_CONSULTA = portfolio.VALOR_CONSULTA;
            p.FORMAS_PAGAMENTO = portfolio.FORMAS_PAGAMENTO;
            p.DURACAO_SESSAO = portfolio.DURACAO_SESSAO;
            p.ATENDE_CONSULTA = portfolio.ATENDE_CONSULTA;
            p.TELEFONE = portfolio.TELEFONE;
            p.CELULAR = portfolio.CELULAR;
            p.EMAIL = portfolio.EMAIL;
            p.FORMACAO = portfolio.FORMACAO;
            p.SOBRE = portfolio.SOBRE;
            p.NOME_PROFISSIONAL = portfolio.NOME_PROFISSIONAL;
            _bancoContext.SaveChanges();

            return portfolio;
        }

        public PortfolioModel SalvarComImagem(PortfolioModel portfolio)
        {
            var p = _bancoContext.PORTFOLIO.FirstOrDefault(p => p.ID_PROFISSIONAL == portfolio.ID_PROFISSIONAL);
            p.ESPECIALIDADE = portfolio.ESPECIALIDADE;
            p.IMAGEM_PROFILE = portfolio.IMAGEM_PROFILE;
            p.VALOR_CONSULTA = portfolio.VALOR_CONSULTA;
            p.FORMAS_PAGAMENTO = portfolio.FORMAS_PAGAMENTO;
            p.DURACAO_SESSAO = portfolio.DURACAO_SESSAO;
            p.ATENDE_CONSULTA = portfolio.ATENDE_CONSULTA;
            p.TELEFONE = portfolio.TELEFONE;
            p.CELULAR = portfolio.CELULAR;
            p.EMAIL = portfolio.EMAIL;
            p.FORMACAO = portfolio.FORMACAO;
            p.SOBRE = portfolio.SOBRE;
            p.NOME_PROFISSIONAL = portfolio.NOME_PROFISSIONAL;
            _bancoContext.SaveChanges();

            return portfolio;
        }

        public PortfolioModel Salvar(PortfolioModel portfolio)
        {
            _bancoContext.Entry(portfolio).State = EntityState.Added;
            _bancoContext.SaveChanges();

            return portfolio;
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
                    NOME_PROFISSIONAL = slug(item.Portfolio.NOME_PROFISSIONAL),
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
                    NOME_PROFISSIONAL = slug(item.Portfolio.NOME_PROFISSIONAL),
                    SOBRE = item.Portfolio.SOBRE,
                    ESPECIALIDADE = item.Portfolio.ESPECIALIDADE,
                    VALOR_CONSULTA = item.Portfolio.VALOR_CONSULTA,
                    DURACAO_SESSAO = item.Portfolio.DURACAO_SESSAO,
                    TELEFONE = item.Portfolio.TELEFONE,
                    CELULAR = item.Portfolio.CELULAR,
                    EMAIL = item.Portfolio.EMAIL,
                    FORMACAO = item.Portfolio.FORMACAO,
                    FORMAS_PAGAMENTO = item.Portfolio.FORMAS_PAGAMENTO,
                    ATENDE_CONSULTA = item.Portfolio.ATENDE_CONSULTA,
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
