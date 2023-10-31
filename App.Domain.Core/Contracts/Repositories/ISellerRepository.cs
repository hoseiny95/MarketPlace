

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories;

public interface ISellerRepository
{
    Task<List<SellerDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerDto> GetById(int sellerId, CancellationToken cancellationToken);
    Task<int> Create(SellerDto seller, CancellationToken cancellationToken);
    Task<int> Update(SellerDto seller, CancellationToken cancellationToken);
    Task Delete(int sellerId, CancellationToken cancellationToken);
}
