using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Domain.AppServices.Products
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<SelectListItem>> GetBaseCategoryItems(CancellationToken cancellationToken)
            => await _categoryService.GetBaseCategoryItems(cancellationToken);
        public async Task<List<SelectListItem>> GetFirstSubCategoryItems(int parentId, CancellationToken cancellationToken)
            => await _categoryService.GetFirstSubCategoryItems(parentId, cancellationToken);

        public async Task<List<SelectListItem>> GetSecondSubCategoryItems(int parentId, CancellationToken cancellationToken)
            => await _categoryService.GetSecondSubCategoryItems(parentId, cancellationToken);
        public async Task<List<CategoryDto>> GetChildren(int categoryId, CancellationToken cancellationToken)
        {
            var res = await _categoryService.GetChildren(categoryId, cancellationToken);

            return res;
        }
        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
            => await _categoryService.GetAll(cancellationToken);   
        
    }
}
