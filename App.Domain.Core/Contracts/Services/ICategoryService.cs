

using App.Domain.Core.Dtos.Products;
using System.Web.Mvc;

namespace App.Domain.Core.Contracts.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
    Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken);
    Task<int> Create(CategoryDto category, CancellationToken cancellationToken);
    Task<int> Update(CategoryDto category, CancellationToken cancellationToken);
    Task<bool> Delete(int categoryId, CancellationToken cancellationToken);
    Task<List<SelectListItem>> GetBaseCategoryItems(CancellationToken cancellationToken);
    Task<List<SelectListItem>> GetFirstSubCategoryItems(int parentId, CancellationToken cancellationToken);
    Task<List<SelectListItem>> GetSecondSubCategoryItems(int parentId, CancellationToken cancellationToken);
    Task<List<CategoryDto>> GetChildren(int categoryId, CancellationToken cancellationToken);

}
