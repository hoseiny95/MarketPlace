using App.Domain.Core.Contracts.AppServices;
using App.Endpoints.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Endpoints.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBoothProductAppService _boothProductAppService;

        public HomeController(ILogger<HomeController> logger, IBoothProductAppService boothProductAppService)
        {
            _logger = logger;
            _boothProductAppService = boothProductAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search(string search, CancellationToken cancellationToken)
        {
            var res = await _boothProductAppService.GetAllByName(search, cancellationToken);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}