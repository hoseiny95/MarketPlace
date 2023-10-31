
using App.Domain.Core.Dtos.Auctions;

namespace App.Domain.Core.Contracts.Services;

public interface IBidService
{
   
    Task<List<BidDto>> GetAll( CancellationToken cancellationToken);
    Task<List<BidDto>> GetAllByAuctionId( int AuctionId,CancellationToken cancellationToken);
    Task<List<BidDto>> GetUserBids(int userID, CancellationToken cancellationToken);
    Task<BidDto> GetById(int bidId, CancellationToken cancellationToken);
    Task Create(BidDto bid, CancellationToken cancellationToken);
    Task Delete(int bidId, CancellationToken cancellationToken);

}
