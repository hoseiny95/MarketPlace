using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface IProductAppService
{
    Task<List<ProductDto>> GetBySubCategoryId(int categoryId, int subcategoryId, int subcategory2Id, CancellationToken cancellationToken);

}
