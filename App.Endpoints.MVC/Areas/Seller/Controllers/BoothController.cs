using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Endpoints.MVC.Areas.Seller.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using System.Text.RegularExpressions;

namespace App.Endpoints.MVC.Areas.Seller.Controllers;

[Area("Seller")]
[Authorize(Roles = "Seller")]
public class BoothController : Controller
{
    private readonly ICategoryAppService _categoryAppService;
    private readonly IProductAppService _productAppService;
    private readonly ISellerAppService _sellerAppService;
    private readonly IBoothProductAppService _boothProductAppService;

    public BoothController(ICategoryAppService categoryAppService, IProductAppService productAppService,
        ISellerAppService sellerAppService, IBoothProductAppService boothProductAppService)
    {
        _categoryAppService = categoryAppService;
        _productAppService = productAppService;
        _sellerAppService = sellerAppService;
        _boothProductAppService = boothProductAppService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> CreateBoothProduct(int id, CancellationToken cancellationToken)
    {
        var groups = await _categoryAppService.GetBaseCategoryItems(cancellationToken);
        ViewData["Groups"] = new SelectList(groups, "Value", "Text");

        var subGrous = await _categoryAppService.GetFirstSubCategoryItems(int.Parse(groups.First().Value), cancellationToken);
        ViewData["SubGroups"] = new SelectList(subGrous, "Value", "Text"); 

        var subGrous2 = await _categoryAppService.GetSecondSubCategoryItems(int.Parse(subGrous.First().Value), cancellationToken);
        ViewData["SubGroups2"] = new SelectList(subGrous2, "Value", "Text");
      
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBoothProduct(CreateBothProductViewModel model, CancellationToken cancellationToken)
    {
        model.products = await _productAppService.GetBySubCategoryId(model.categoryId,
            model.subcategoryId, model.subcategory2Id, cancellationToken);
        var groups = await _categoryAppService.GetBaseCategoryItems(cancellationToken);
        ViewData["Groups"] = new SelectList(groups, "Value", "Text");

        var subGrous = await _categoryAppService.GetFirstSubCategoryItems(int.Parse(groups.First().Value), cancellationToken);
        ViewData["SubGroups"] = new SelectList(subGrous, "Value", "Text");

        var subGrous2 = await _categoryAppService.GetSecondSubCategoryItems(int.Parse(subGrous.First().Value), cancellationToken);
        ViewData["SubGroups2"] = new SelectList(subGrous2, "Value", "Text");
        return View(model);
    }
    public async Task<IActionResult> GetFirstSubGroups(int id, CancellationToken cancellationToken)
    {
        var subGrous = await _categoryAppService.GetFirstSubCategoryItems(id, cancellationToken);
      
      
        return Json(new SelectList(subGrous, "Value", "Text"));

    }
    public async Task<IActionResult> GetSecondSubGroups(int id, CancellationToken cancellationToken)
    {
        var subGrous = await _categoryAppService.GetSecondSubCategoryItems(id, cancellationToken);
     
        return Json(new SelectList(subGrous, "Value", "Text"));

    }
    public async Task<IActionResult> AddProduct(int id, CancellationToken cancellationToken)
    {
        var res = await _productAppService.GetbyId(id, cancellationToken);
        var model = new AddProductViewModel()
        {
            productId = id,
            imagepath = res.BoothProducts.First().ProductImages.First().Image.ImagePath,
            productName = res.Name,
            ImageId = res.BoothProducts.First().ProductImages.First().Image.Id
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductViewModel model, IFormFile photo, CancellationToken cancellationToken)
    {
        int boothId = await _sellerAppService.GetSellerBoothId(User.Identity.Name, cancellationToken);
        var boothProduct = new BoothProductDto()
        {
            BothId = boothId,
            ProductId = model.productId,
            Price = model.price,
            Quantity = model.quantity,
            IsBid = model.IsBid,
        };
        await _boothProductAppService.Create(boothProduct, photo, model.ImageId, cancellationToken);
        return LocalRedirect("/Seller/home");
    }
}
