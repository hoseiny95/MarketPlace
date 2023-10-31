using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products;

public class CategoryAttributeTitleService : ICategoryAttributeTitleService
{
    public Task Create(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int categoryAttributeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryAttributeTitleDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryAttributeTitleDto> GetById(int categoryAttributeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
