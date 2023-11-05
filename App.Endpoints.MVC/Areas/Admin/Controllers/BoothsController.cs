using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class BoothsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
