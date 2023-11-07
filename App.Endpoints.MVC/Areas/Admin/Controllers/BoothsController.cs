using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dtos.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BoothsController : Controller
{
    private readonly IBoothAppService _boothAppService;

    public BoothsController(IBoothAppService boothAppService)
    {
        _boothAppService = boothAppService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _boothAppService.GetAll(cancellationToken);
        return View(result);
    }
    [HttpGet]
    public async Task<IActionResult> EditBooth(int id ,CancellationToken cancellationToken)
    {
        var result = await _boothAppService.GetById(id , cancellationToken);
        return View(result);
    }
    [HttpPost]
    public async Task<IActionResult> EditBooth(BoothDto model, IFormFile photo, CancellationToken cancellationToken)
    {
        await _boothAppService.Update(model, photo, cancellationToken);
        var result = await _boothAppService.GetAll(cancellationToken);
        return View(nameof(Index), result);
    }
    public async Task<IActionResult> DeletedBooth(CancellationToken cancellationToken)
    {
        var result = await _boothAppService.GetAllDeleted(cancellationToken);
        return View(result);
    }
    public async Task<IActionResult> DeleteBooth(int id ,CancellationToken cancellationToken)
    {
        await _boothAppService.Delete(id , cancellationToken);
        var result = await _boothAppService.GetAllDeleted(cancellationToken);
        return View(nameof(DeletedBooth), result);
    }
    public async Task<IActionResult> ReturnBooth(int id, CancellationToken cancellationToken)
    {
        await _boothAppService.Return(id , cancellationToken);
        var result = await _boothAppService.GetAll(cancellationToken);
        return View(nameof(Index), result);
    }
}
