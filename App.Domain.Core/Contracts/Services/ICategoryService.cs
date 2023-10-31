

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
    Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken);
    Task<int> Create(CategoryDto category, CancellationToken cancellationToken);
    Task<int> Update(CategoryDto category, CancellationToken cancellationToken);
    Task<bool> Delete(int categoryId, CancellationToken cancellationToken);

}
