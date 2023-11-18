using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

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

    public async Task<List<SelectListItem>> GetBaseCategoryItems(CancellationToken cancellationToken)
        => await _categoryRepository.GetBaseCategoryItems(cancellationToken);

    public async Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken)
        => await _categoryRepository.GetById(categoryId, cancellationToken);

    public async Task<List<SelectListItem>> GetFirstSubCategoryItems(int parentId, CancellationToken cancellationToken)
        => await _categoryRepository.GetFirstSubCategoryItems(parentId, cancellationToken);

    public async Task<List<SelectListItem>> GetSecondSubCategoryItems(int parentId, CancellationToken cancellationToken)
        => await _categoryRepository.GetSecondSubCategoryItems(parentId, cancellationToken);

    public Task<int> Update(CategoryDto category, CancellationToken cancellationToken)
        => _categoryRepository.Update(category, cancellationToken);

    public async Task<List<CategoryDto>> GetChildren(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(categoryId, cancellationToken);
        List<CategoryDto> Nodes = new List<CategoryDto>();
        await AddChildren(Nodes, category);
        return Nodes;
    }
    protected async Task AddChildren(List<CategoryDto> Nodes, CategoryDto Node)
    {
        foreach (CategoryDto thisNode in Node.InverseParent)
        {
            Nodes.Add(thisNode);
            var thisNode2 = await _categoryRepository.GetById(thisNode.Id, default);
            await AddChildren(Nodes, thisNode2);
        }
    }
}
