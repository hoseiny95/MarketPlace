

using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services;

public interface ISellerService
{
    Task<List<SellerDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerDto> GetById(int sellerId, CancellationToken cancellationToken);
    Task<int> Create(SellerDto seller, CancellationToken cancellationToken);
    Task<int> Update(SellerDto seller, CancellationToken cancellationToken);
    Task<bool> Delete(int sellerId, CancellationToken cancellationToken);
    Task<List<BoothProductDto>> GetBoothsByUserId(int userId, CancellationToken cancellationToken);
    Task<int> GetBoothId(int userId, CancellationToken cancellationToken);
    Task<SellerDto> GetByBoothProductId(int boothProductId, CancellationToken cancellationToken);
    Task<SellerDto> GetbyUserId(int userId, CancellationToken cancellationToken);
}
