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

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Create(ProductDto newProduct, CancellationToken cancellationToken)
        => await _productRepository.Create(newProduct, cancellationToken);

    public async Task<bool> Delete(int ProductId, CancellationToken cancellationToken)
    {
        try
        {
            await _productRepository.Delete(ProductId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        => await _productRepository.GetAll(cancellationToken);

    public async Task<List<ProductDto>> GetByCategoryId(List<CategoryDto> categories, CancellationToken cancellationToken)
        => await _productRepository.GetByCategoryId(categories, cancellationToken);

    public async Task<ProductDto> GetById(int ProductId, CancellationToken cancellationToken)
        => await _productRepository.GetById(ProductId, cancellationToken);

    public async Task<List<int>> GetIDByCategories(List<CategoryDto> categories, CancellationToken cancellationToken)
        => await _productRepository.GetIDByCategories(categories, cancellationToken);

    public async Task<int> Update(ProductDto Product, CancellationToken cancellationToken)
        => await _productRepository.Update(Product, cancellationToken);
}
