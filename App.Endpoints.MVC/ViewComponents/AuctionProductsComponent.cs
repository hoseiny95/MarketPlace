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

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.type = id;
        var result = await _boothProductService.GetAll(default);
        var res = result.Skip(0).Take(8).ToList();
        return View(res);
    }
}
