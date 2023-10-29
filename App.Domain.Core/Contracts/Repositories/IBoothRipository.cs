

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Repositories;

public interface IBoothRipository
{
    Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken);
    Task Create(BoothDto booth, CancellationToken cancellationToken);
    Task Update(BoothDto booth, CancellationToken cancellationToken);
    Task Delete(int boothId, CancellationToken cancellationToken);

}
