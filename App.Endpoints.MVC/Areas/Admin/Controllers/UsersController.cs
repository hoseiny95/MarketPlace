using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace App.Endpoints.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class UsersController : Controller
{
    private readonly IAppUserService _appUserService;

    public UsersController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _appUserService.GetAll(cancellationToken);
        return View(result);
    }
    public IActionResult CreateUser()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser(AppUserDto user, string SelectedRoles, CancellationToken cancellationToken)
    {
        user.Role = SelectedRoles;
         await _appUserService.Create(user, cancellationToken);
        return Redirect("/admin/users") ; 
    }
    public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
    {
        await _appUserService.Delete(id, cancellationToken);

        return Redirect("/admin/users");
    }
    public async Task<IActionResult> EditUser(int id, CancellationToken cancellationToken)
    {
        var result = await _appUserService.GetById(id, cancellationToken);
        return View(result);
    }
    [HttpPost]
    public async Task<IActionResult> EditUser(AppUserDto user, string SelectedRoles, CancellationToken cancellationToken)
    {
        user.Role = SelectedRoles==null ? user.Role: SelectedRoles;
        await _appUserService.Update(user, cancellationToken);
        return Redirect("/admin/users");
    }
}
