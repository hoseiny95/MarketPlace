using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Auctions
{
    public class BidService : IBidService
    {
        public Task Create(BidDto bid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int bidId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BidDto>> GetAllByAuctionId(int AuctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BidDto> GetById(int bidId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BidDto>> GetUserBids(int userID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
