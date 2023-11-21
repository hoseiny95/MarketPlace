using App.Domain.Core.Contracts.AppServices;
using App.Endpoints.MVC.Areas.Seller.Models;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.Threading;

namespace App.Endpoints.MVC.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class HomeController : Controller
    {
        private readonly ISellerAppService _sellerAppService;
        private readonly IAuctionAppService _auctionAppService;
        private readonly IRecurringJobManager _recurringJobManager;

        public HomeController(ISellerAppService sellerAppService, IAuctionAppService auctionAppService,
            IRecurringJobManager recurringJobManager)
        {
            _sellerAppService = sellerAppService;
            _auctionAppService = auctionAppService;
            _recurringJobManager = recurringJobManager;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var res = await _sellerAppService.GetSellerBooths(User.Identity.Name, cancellationToken);
            res.RemoveAll(item => item.IsBid == true);
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
                var id = await _auctionAppService.StartAuction(boothId, model.MinPrice, model.Duration, model.BoothProductId, 
                    cancellationToken);
                BackgroundJob.Schedule<IAuctionAppService>(x => x.EndAuction(id,default), DateTime.Now.AddHours(model.Duration));
            }
            return View(model);
        }
    }
}
