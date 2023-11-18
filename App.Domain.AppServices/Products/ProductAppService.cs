using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductAppService(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<List<ProductDto>> GetBySubCategoryId(int categoryId, int subcategoryId, int subcategory2Id,
            CancellationToken cancellationToken)
        {
            var result = new List<ProductDto>();
            var categories = new List<CategoryDto>();
            var category = new CategoryDto();
            if (categoryId != 0 && subcategoryId == 0 && subcategory2Id == 0)
            {
                categories = await _categoryService.GetChildren(categoryId, cancellationToken);
                category  = await _categoryService.GetById(categoryId, cancellationToken);
                categories.Add(category);
                result = await _productService.GetByCategoryId(categories, cancellationToken);
            }
            else if(categoryId != 0 && subcategoryId != 0 && subcategory2Id == 0)
            {
                categories = await _categoryService.GetChildren(subcategoryId, cancellationToken);
                category = await _categoryService.GetById(subcategoryId, cancellationToken);
                categories.Add(category);
                result = await _productService.GetByCategoryId(categories, cancellationToken);
            }
            else if(categoryId != 0 && subcategoryId != 0 && subcategory2Id != 0)
            {
                categories = await _categoryService.GetChildren(subcategory2Id, cancellationToken);
                category = await _categoryService.GetById(subcategory2Id, cancellationToken);
                categories.Add(category);
                result = await _productService.GetByCategoryId(categories, cancellationToken);
            }
            return result;  
        }
    }
}
