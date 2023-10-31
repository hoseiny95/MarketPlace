

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface IBoothRepository
{
    Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken);
    Task<int> Create(BoothDto booth, CancellationToken cancellationToken);
    Task<int> Update(BoothDto booth, CancellationToken cancellationToken);
    Task Delete(int boothId, CancellationToken cancellationToken);

}
