using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Controllers
{
    public class BoothController : Controller
    {
        private readonly IBoothAppService _boothAppService;
        private readonly IBoothProductAppService _boothProductAppService;

        public BoothController(IBoothAppService boothAppService, IBoothProductAppService boothProductAppService)
        {
            _boothAppService = boothAppService;
            _boothProductAppService = boothProductAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var booths = await _boothAppService.GetAll(cancellationToken);

            return View(booths);
        }
        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var model = await _boothProductAppService.GetByBoothId(id, cancellationToken);

            return View(model);
        }
    }
}
