using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dtos.Users;
using App.Endpoints.MVC.Areas.Seller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using System.Text.RegularExpressions;

namespace App.Endpoints.MVC.Areas.Seller.Controllers;

[Area("Seller")]
public class BoothController : Controller
{
    private readonly ICategoryAppService _categoryAppService;
    private readonly IProductAppService _productAppService;
    private readonly ISellerAppService _sellerAppService;

    public BoothController(ICategoryAppService categoryAppService, IProductAppService productAppService, 
        ISellerAppService sellerAppService)
    {
        _categoryAppService = categoryAppService;
        _productAppService = productAppService;
        _sellerAppService = sellerAppService;
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
    public async Task<IActionResult> AddProduct(int id)
    {
        
        return View();
    }
}
