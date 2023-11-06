

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Services;

public interface IBoothService
{
    Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken);
    Task<int> Create(BoothDto booth, CancellationToken cancellationToken);
    Task<int> Update(BoothDto booth, CancellationToken cancellationToken);
    Task<bool> Delete(int boothId, CancellationToken cancellationToken);
    Task<List<BoothDto>> GetAllDeleted(CancellationToken cancellationToken);

}
