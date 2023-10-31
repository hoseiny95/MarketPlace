using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products;

public class ProductService : IProductService
{
    public Task Create(ProductDto newProduct, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int ProductId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetById(int ProductId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProductDto Product, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
