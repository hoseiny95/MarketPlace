

using App.Domain.Core.Dtos.Products;

namespace App.Domain.Core.Contracts.Services;

public interface IBoothProductService
{
    Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken);
    Task Create(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task Update(BoothProductDto boothProduct, CancellationToken cancellationToken);
    Task Delete(int boothProductId, CancellationToken cancellationToken);

}
