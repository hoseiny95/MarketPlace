﻿using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductsController : Controller
{
    private readonly IBoothProductService _boothProductService;
    private readonly IBoothProductAppService _boothProductAppService;

    public ProductsController(IBoothProductService boothProductService, IBoothProductAppService boothProductAppService)
    {
        _boothProductService = boothProductService;
        _boothProductAppService = boothProductAppService;
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
    public async Task<IActionResult> EditProduct(ProductAdminDto model,IFormFile photo, CancellationToken cancellationToken)
    {
        await _boothProductAppService.UpdateAdminProduct(model, photo, cancellationToken);
        var res = await _boothProductService.GetAdminProducts(cancellationToken);
        return View(nameof(Index), res);
    }
    [HttpGet]
    public async Task<IActionResult> ConfirmProduct( CancellationToken cancellationToken)
    {
        var res = await _boothProductService.GetAdminProductsNotConfirm( cancellationToken);
        return View(res);
    }
    [HttpPost]
    public async  Task<IActionResult> ConfirmProduct(int id,string confitm,string refuse, CancellationToken cancellationToken)
    {
        await _boothProductAppService.ConfirmProduct(id, confitm, refuse, cancellationToken);
        var res = await _boothProductService.GetAdminProductsNotConfirm(cancellationToken);
        return View(res);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
         await _boothProductService.Delete(id,cancellationToken);
        var res = await _boothProductService.GetAdminProducts(cancellationToken);
        return View(nameof(Index),res);
    }

}
