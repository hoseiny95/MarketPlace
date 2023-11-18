using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {
        private readonly ISellerAppService _sellerAppService;

        public HomeController(ISellerAppService sellerAppService)
        {
            _sellerAppService = sellerAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        
        {
            var res = await _sellerAppService.GetSellerBooths(User.Identity.Name, cancellationToken);
            var name = res.First().Both.Name;
            return View(res);
        }
    }
}
