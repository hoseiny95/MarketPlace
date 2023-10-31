using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products;

public class CategoryService : ICategoryService
{
    public Task Create(CategoryDto category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoryDto category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
