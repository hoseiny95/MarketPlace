using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.ViewComponents;

public class AuctionProductsComponent : ViewComponent
{
    private readonly IBoothProductService _boothProductService;

    public AuctionProductsComponent(IBoothProductService boothProductService)
    {
        _boothProductService = boothProductService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _boothProductService.GetAll(default);
        return View(result);
    }
}
