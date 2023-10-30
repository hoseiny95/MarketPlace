

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface ICategoryRepository
{
    Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
    Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken);
    Task Create(CategoryDto category, CancellationToken cancellationToken);
    Task Update(CategoryDto category, CancellationToken cancellationToken);
    Task Delete(int categoryId, CancellationToken cancellationToken);

}
