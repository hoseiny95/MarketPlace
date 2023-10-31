using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Services;

public interface ICategoryAttributeTitleService
{
    Task<List<CategoryAttributeTitleDto>> GetAll(CancellationToken cancellationToken);
    Task<CategoryAttributeTitleDto> GetById(int categoryAttributeId, CancellationToken cancellationToken);
    Task<int> Create(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken);
    Task<int> Update(CategoryAttributeTitleDto categoryAttribute, CancellationToken cancellationToken);
    Task<bool> Delete(int categoryAttributeId, CancellationToken cancellationToken);
}
