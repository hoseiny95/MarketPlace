using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.Areas.Seller.ViewComponents
{
    [Area("Seller")]
    [ViewComponent(Name = "SidebarComponent")]
    public class SidebarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("Sidebar"));
        }
    }
}
