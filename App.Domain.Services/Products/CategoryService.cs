using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> Create(CategoryDto category, CancellationToken cancellationToken)
        => await _categoryRepository.Create(category, cancellationToken);

    public async Task<bool> Delete(int categoryId, CancellationToken cancellationToken)
    {
        try
        {
            await _categoryRepository.Delete(categoryId,cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        => await _categoryRepository.GetAll(cancellationToken);

    public async Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken)
        => await _categoryRepository.GetById(categoryId, cancellationToken);

    public Task<int> Update(CategoryDto category, CancellationToken cancellationToken)
        => _categoryRepository.Update(category, cancellationToken);
}
