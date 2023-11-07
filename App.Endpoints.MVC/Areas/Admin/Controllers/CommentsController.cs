using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CommentsController : Controller
{
    private readonly ICommentAppService _commentAppService;

    public CommentsController(ICommentAppService commentAppService)
    {
        _commentAppService = commentAppService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _commentAppService.GetAll(cancellationToken);
        return View(result);
    }
    [HttpGet]
    public async Task<IActionResult> Confirm(int id ,CancellationToken cancellationToken)
    {
        await _commentAppService.ConfirmComment(id, cancellationToken);
        var result = await _commentAppService.GetAll(cancellationToken);
        return View(nameof(Index),result);
    }
    [HttpGet]
    public async Task<IActionResult> Refuse(int id, CancellationToken cancellationToken)
    {
        await _commentAppService.RefuseComment(id, cancellationToken);
        var result = await _commentAppService.GetAll(cancellationToken);
        return View(nameof(Index),result);
    }
}
