using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Seller.Controllers;

[Area("Seller")]
public class UserPanelController : Controller
{
    private readonly ISellerAppService _sellerAppService;

    public UserPanelController(ISellerAppService sellerAppService)
    {
        _sellerAppService = sellerAppService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var res = await _sellerAppService.GetSellerByUserName(User.Identity.Name, cancellationToken);
        return View(res);
    }
}
