using App.Domain.Core.Contracts.AppServices;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace App.Endpoints.MVC.Areas.Seller.Controllers;

[Area("Seller")]
public class AuctionController : Controller
{
    private readonly ISellerAppService _sellerAppService;
    private readonly IAuctionAppService _auctionAppService;
    private readonly IRecurringJobManager _recurringJobManager;

    public AuctionController(ISellerAppService sellerAppService, IAuctionAppService auctionAppService,
        IRecurringJobManager recurringJobManager)
    {
        _sellerAppService = sellerAppService;
        _auctionAppService = auctionAppService;
        _recurringJobManager = recurringJobManager;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var res = await _sellerAppService.GetSellerBooths(User.Identity.Name, cancellationToken);
        res.RemoveAll(item => item.IsBid ==  false);
        return View(res);
    }
}
