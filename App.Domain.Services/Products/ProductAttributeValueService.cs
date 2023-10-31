using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products;

internal class ProductAttributeValueService : IProductAttributeValueService
{
    public Task Create(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int productAttributeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductAttributeValueDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductAttributeValueDto> GetById(int productAttributeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
