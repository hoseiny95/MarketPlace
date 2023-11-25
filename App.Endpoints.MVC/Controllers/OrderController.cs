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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShowOrder(int orderId, CancellationToken cancellationToken)
        {
            var model = _orderAppService.GetbyId(orderId, cancellationToken);
            return View(model);
        }
        public async Task<IActionResult> FinishOrder(int orderId, CancellationToken cancellationToken)
        {
            var model = _orderAppService.GetbyId(orderId, cancellationToken);
            return View(model);
        }
    }
}
