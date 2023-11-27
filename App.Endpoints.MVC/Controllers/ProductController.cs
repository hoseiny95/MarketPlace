using App.Domain.AppServices.Products;
using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Endpoints.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBoothProductAppService _boothProductAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IOrderAppService _orderAppService;

        public ProductController(IBoothProductAppService boothProductAppService, 
            ICategoryAppService categoryAppService, IOrderAppService orderAppService)
        {
            _boothProductAppService = boothProductAppService;
            _categoryAppService = categoryAppService;
            _orderAppService = orderAppService;
        }

        public async Task<IActionResult> Index( List<int> selectedGroups, CancellationToken cancellationToken, int pageId = 1, string orderByType = "date",
            int startPrice = 0, int endPrice = 0)
        {
            var model = await _boothProductAppService.GetAllPaging(cancellationToken, selectedGroups, pageId, orderByType, startPrice, endPrice);
            ViewBag.selectedGroups = selectedGroups;
            ViewBag.pageId = pageId;
            var categories = await _categoryAppService.GetAll(cancellationToken);
            ViewBag.Groups = categories;

            return View(model);
        }
        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var model = await _boothProductAppService.GetById(id, cancellationToken);
            return View(model);
        }
        public async Task<IActionResult> BuyProduct(int id, CancellationToken cancellationToken)
        {
            
             await _orderAppService.ByeProduct(id, User.Identity.Name, cancellationToken);
            return RedirectToAction("ShowOrder","Order",new {username = User.Identity.Name });
        }

    }
}
