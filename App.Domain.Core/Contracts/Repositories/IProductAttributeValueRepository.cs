using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repositories
{
    public interface IProductAttributeValueRepository
    {
        Task<List<ProductAttributeValueDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductAttributeValueDto> GetById(int productAttributeId, CancellationToken cancellationToken);
        Task Create(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken);
        Task Update(ProductAttributeValueDto productAttribute, CancellationToken cancellationToken);
        Task Delete(int productAttributeId, CancellationToken cancellationToken);
    }
}
