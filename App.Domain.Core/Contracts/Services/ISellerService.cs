

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services;

public interface ISellerService
{
    Task<List<SellerDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerDto> GetById(int sellerId, CancellationToken cancellationToken);
    Task Create(SellerDto seller, CancellationToken cancellationToken);
    Task Update(SellerDto seller, CancellationToken cancellationToken);
    Task Delete(int sellerId, CancellationToken cancellationToken);
}
