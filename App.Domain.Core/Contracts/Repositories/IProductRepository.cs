
using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface IProductRepository
{
   
    Task<List<ProductDto>> GetAll( CancellationToken cancellationToken);
    Task<ProductDto> GetById(int ProductId, CancellationToken cancellationToken);
    Task<int> Create(ProductDto newProduct, CancellationToken cancellationToken);
    Task<int> Update(ProductDto Product, CancellationToken cancellationToken);
    Task Delete(int ProductId, CancellationToken cancellationToken);
    Task<List<ProductDto>> GetByCategoryId(List<CategoryDto> categories, CancellationToken cancellationToken);


}
