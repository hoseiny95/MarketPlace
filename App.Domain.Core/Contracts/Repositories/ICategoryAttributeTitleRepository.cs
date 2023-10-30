using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repositories
{
    public interface ICategoryAttributeTitleRepository
    {
        Task<List<CategoryAttributeTitleDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryAttributeTitleDto> GetById(int categoryAttributeId, CancellationToken cancellationToken);
        Task Create(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken);
        Task Update(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken);
        Task Delete(int categoryAttributeId, CancellationToken cancellationToken);
    }
}
