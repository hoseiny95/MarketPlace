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

public class ProductAttributeValueService : IProductAttributeValueService
{
    private readonly IProductAttributeValueRepository _productAttributeValueRepository;

    public ProductAttributeValueService(IProductAttributeValueRepository productAttributeValueRepository)
    {
        _productAttributeValueRepository = productAttributeValueRepository;
    }

    public async Task<int> Create(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken)
        => await _productAttributeValueRepository.Create(productAttribute, cancellationToken);

    public async Task<bool> Delete(int productAttributeId, CancellationToken cancellationToken)
    {
        try
        {
            await _productAttributeValueRepository.Delete(productAttributeId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<ProductAttributeValueDto>> GetAll(CancellationToken cancellationToken)
        => await _productAttributeValueRepository.GetAll(cancellationToken);

    public async Task<ProductAttributeValueDto> GetById(int productAttributeId, CancellationToken cancellationToken)
        => await _productAttributeValueRepository.GetById(productAttributeId, cancellationToken);

    public async Task<int> Update(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken)
        => await _productAttributeValueRepository.Update(productAttribute, cancellationToken);
}
