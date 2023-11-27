using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var model = await _orderAppService.GetAllbyUsername(User.Identity.Name, cancellationToken);
            return View(model);
        }
        public async Task<IActionResult> ShowOrder(string username, CancellationToken cancellationToken)
        {
            var model = await _orderAppService.GetbyUsername(username, cancellationToken);
            return View(model);
        } 
        public async Task<IActionResult> ShowOrderByOrderId(int id, CancellationToken cancellationToken)
        {
            var model = await _orderAppService.GetbyId(id , cancellationToken);
            return View(nameof(ShowOrder),model);
        }
        public async Task<IActionResult> FinishOrder(int id, CancellationToken cancellationToken)
        {
            await _orderAppService.FinishOrder(id, cancellationToken);
            return Redirect("/home/index");
        }
    }
}
