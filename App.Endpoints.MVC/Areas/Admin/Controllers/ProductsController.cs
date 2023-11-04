using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Admin;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    private readonly IBoothProductService _boothProductService;

    public ProductsController(IBoothProductService boothProductService)
    {
        _boothProductService = boothProductService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var res = await _boothProductService.GetAdminProducts(cancellationToken);

        return View(res);
    }
    [HttpGet]
    public async Task<IActionResult> EditProduct(int id,CancellationToken cancellationToken)
    {
       var res = await _boothProductService.GetAdminProductsbyId(id, cancellationToken);
        return View(res);
    }
    [HttpPost]
    public IActionResult EditProduct(ProductAdminDto model,IFormFile photo)
    {
        return View();
    }

}
