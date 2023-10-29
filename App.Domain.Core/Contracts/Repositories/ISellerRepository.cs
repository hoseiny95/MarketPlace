

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories;

public interface ISellerRepository
{
    Task<List<SellerDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerDto> GetById(string userId, CancellationToken cancellationToken);
    Task Create(SellerDto seller, CancellationToken cancellationToken);
    Task Update(SellerDto seller, CancellationToken cancellationToken);
    Task Delete(int sellerId, CancellationToken cancellationToken);
}
