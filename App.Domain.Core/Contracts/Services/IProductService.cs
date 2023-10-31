
using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Services;

public interface IProductService
{
   
    Task<List<ProductDto>> GetAll( CancellationToken cancellationToken);
    Task<ProductDto> GetById(int ProductId, CancellationToken cancellationToken);
    Task<int> Create(ProductDto newProduct, CancellationToken cancellationToken);
    Task<int> Update(ProductDto Product, CancellationToken cancellationToken);
    Task<bool> Delete(int ProductId, CancellationToken cancellationToken);
    
}
