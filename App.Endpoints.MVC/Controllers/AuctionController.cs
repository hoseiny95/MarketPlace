using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionAppService _auctionAppService;

        public AuctionController(IAuctionAppService auctionAppService)
        {
            _auctionAppService = auctionAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetPrice(int Auction, double price, CancellationToken cancellationToken)
        {
            var auction = await _auctionAppService.GetLastPrice(Auction, cancellationToken);
            if (auction >= price)
            {
                ViewBag.SetBid = "false";
                return View("Index");
            }
            await _auctionAppService.CreateBid(User.Identity.Name, Auction, price, cancellationToken);
            ViewBag.BidSuccess = "true";
            return View("Index");
        }
    }
}
