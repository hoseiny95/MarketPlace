﻿

using App.Domain.Core.Dtos.Auctions;

namespace App.Domain.Core.Contracts.Repositories;

public interface IAuctionRepository
{
    Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken);
    Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken);
    Task<int> Create(AuctionDto auction, CancellationToken cancellationToken);
    Task<int> Update(AuctionDto auction, CancellationToken cancellationToken);
    Task Delete(int auctionId, CancellationToken cancellationToken);
  
}
