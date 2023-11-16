using App.Domain.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Endpoints.MVC.ViewComponents
{
    public class CategoryGroupComponent : ViewComponent
    {
        private readonly ICategoryService _categorySrvice;

        public CategoryGroupComponent(ICategoryService categorySrvice)
        {
            _categorySrvice = categorySrvice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _categorySrvice.GetAll(default);
            return await Task.FromResult((IViewComponentResult)View("CategoryGroup", model));
        }
    }
}
