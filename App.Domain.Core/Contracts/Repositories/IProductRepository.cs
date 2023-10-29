
using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface IProductRepository
{
   
    Task<List<ProductDto>> GetAll( CancellationToken cancellationToken);
    Task<ProductDto> GetById(int ProductId, CancellationToken cancellationToken);
    Task Create(ProductDto newProduct, CancellationToken cancellationToken);
    Task Update(ProductDto Product, CancellationToken cancellationToken);
    Task Delete(int ProductId, CancellationToken cancellationToken);
    
}
