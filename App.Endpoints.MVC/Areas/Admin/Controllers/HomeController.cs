using App.Domain.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    private readonly IWalletHistoryService _walletHistoryService;

    public HomeController(IWalletHistoryService walletHistoryService)
    {
        _walletHistoryService = walletHistoryService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _walletHistoryService.GetAll(cancellationToken);
        return View(result);
    }
}
