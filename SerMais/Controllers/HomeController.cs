using Microsoft.AspNetCore.Mvc;
using SerMais.Models;
using SerMais.Repositorio;
using System.Diagnostics;

namespace SerMais.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPortfolioRepositorio _portfolioRepositorio;

        public HomeController(ILogger<HomeController> logger, IPortfolioRepositorio portfolioRepositorio)
        {
            _logger = logger;
            _portfolioRepositorio= portfolioRepositorio;
        }

        public IActionResult Index()
        {
            var portfolios = _portfolioRepositorio.BuscarTodos();
            return View(portfolios);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}