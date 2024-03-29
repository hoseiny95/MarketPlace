﻿

using App.Domain.Core.Dtos.Auctions;

namespace App.Domain.Core.Contracts.Services;

public interface IAuctionService
{
    Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken);
    Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken);
    Task<int> Create(AuctionDto auction, CancellationToken cancellationToken);
    Task<int> Update(AuctionDto auction, CancellationToken cancellationToken);
    Task<bool> Delete(int auctionId, CancellationToken cancellationToken);
  
}
