

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface IBoothProductRepository
{
    Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken);
    Task<int> Create(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task<int> Update(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task Delete(int boothProductId, CancellationToken cancellationToken);

}
