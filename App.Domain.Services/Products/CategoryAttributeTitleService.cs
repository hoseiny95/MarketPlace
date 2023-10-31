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

public class CategoryAttributeTitleService : ICategoryAttributeTitleService
{
    private readonly ICategoryAttributeTitleRepository _categoryAttributeTitleRepository;

    public CategoryAttributeTitleService(ICategoryAttributeTitleRepository categoryAttributeTitleRepository)
    {
        _categoryAttributeTitleRepository = categoryAttributeTitleRepository;
    }

    public async Task<int> Create(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken)
        => await _categoryAttributeTitleRepository.Create(categoryAttribute, cancellationToken);

    public async Task<bool> Delete(int categoryAttributeId, CancellationToken cancellationToken)
    {
        try
        {
            await _categoryAttributeTitleRepository.Delete(categoryAttributeId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<CategoryAttributeTitleDto>> GetAll(CancellationToken cancellationToken)
        => await _categoryAttributeTitleRepository.GetAll(cancellationToken);

    public async Task<CategoryAttributeTitleDto> GetById(int categoryAttributeId, CancellationToken cancellationToken)
        => await _categoryAttributeTitleRepository.GetById(categoryAttributeId, cancellationToken);

    public async Task<int> Update(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken)
        => await _categoryAttributeTitleRepository.Update(categoryAttribute, cancellationToken);
}
