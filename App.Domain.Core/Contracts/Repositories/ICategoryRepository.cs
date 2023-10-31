

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface ICategoryRepository
{
    Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
    Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken);
    Task<int> Create(CategoryDto category, CancellationToken cancellationToken);
    Task<int> Update(CategoryDto category, CancellationToken cancellationToken);
    Task Delete(int categoryId, CancellationToken cancellationToken);

}
