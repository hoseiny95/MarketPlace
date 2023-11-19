using App.Domain.Core.Contracts.AppServices;
using App.Endpoints.MVC.Areas.Seller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.Threading;

namespace App.Endpoints.MVC.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {
        private readonly ISellerAppService _sellerAppService;
        private readonly IAuctionAppService _auctionAppService;

        public HomeController(ISellerAppService sellerAppService, IAuctionAppService auctionAppService)
        {
            _sellerAppService = sellerAppService;
            _auctionAppService = auctionAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var res = await _sellerAppService.GetSellerBooths(User.Identity.Name, cancellationToken);
            return View(res);
        }
        public async Task<IActionResult> StartAuction(int id, CancellationToken cancellationToken)
        {
            var model = new AddAuctionViewModel()
            {
                BoothProductId = id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> StartAuction(AddAuctionViewModel model, CancellationToken cancellationToken)
        {
            int boothId = await _sellerAppService.GetSellerBoothId(User.Identity.Name, cancellationToken);
            model.BoothId = boothId;
            if (ModelState.IsValid)
            {
                await _auctionAppService.StartAuction(boothId, model.MinPrice, model.Duration, model.BoothProductId, cancellationToken);
            }
            return View(model);
        }
    }
}
