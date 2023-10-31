using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Auctions
{
    public class AuctionService : IAuctionService
    {
        public Task Create(AuctionDto auction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(AuctionDto auction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
