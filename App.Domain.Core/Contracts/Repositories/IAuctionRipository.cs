

using App.Domain.Core.Dtos.Auctions;

namespace App.Domain.Core.Contracts.Repositories;

public interface IAuctionRipository
{
    Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken);
    Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken);
    Task Create(AuctionDto auction, CancellationToken cancellationToken);
    Task Update(AuctionDto auction, CancellationToken cancellationToken);
    Task Delete(int auctionId, CancellationToken cancellationToken);
  
}
