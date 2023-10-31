using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Services
{
    public interface IProductAttributeValueService
    {
        Task<List<ProductAttributeValueDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductAttributeValueDto> GetById(int productAttributeId, CancellationToken cancellationToken);
        Task<int> Create(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken);
        Task<int> Update(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken);
        Task<bool> Delete(int productAttributeId, CancellationToken cancellationToken);
    }
}
