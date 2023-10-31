using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Entities.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Auctions
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        public async Task<int> Create(BidDto bid, CancellationToken cancellationToken)
                  => await _bidRepository.Create(bid, cancellationToken);

        public async Task<bool> Delete(int bidId, CancellationToken cancellationToken)
        {
            try
            {
                await _bidRepository.Delete(bidId, cancellationToken);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
            => await _bidRepository.GetAll(cancellationToken);
       

        public async Task<List<BidDto>> GetAllByAuctionId(int AuctionId, CancellationToken cancellationToken)
            => await _bidRepository.GetAllByAuctionId(AuctionId, cancellationToken);

        public async Task<BidDto> GetById(int bidId, CancellationToken cancellationToken)
            => await _bidRepository.GetById(bidId, cancellationToken);

        public async Task<List<BidDto>> GetUserBids(int userID, CancellationToken cancellationToken)
            => await _bidRepository.GetUserBids(userID, cancellationToken);
       
    }
}
