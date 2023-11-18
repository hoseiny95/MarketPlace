using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Domain.Core.Contracts.AppServices;

public interface ICategoryAppService
{
    Task<List<SelectListItem>> GetBaseCategoryItems(CancellationToken cancellationToken);
    Task<List<SelectListItem>> GetFirstSubCategoryItems(int parentId, CancellationToken cancellationToken);
    Task<List<SelectListItem>> GetSecondSubCategoryItems(int parentId, CancellationToken cancellationToken);
    Task<List<CategoryDto>> GetChildren(int categoryId, CancellationToken cancellationToken);
}
