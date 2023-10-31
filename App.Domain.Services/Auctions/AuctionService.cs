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
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        public async Task<int> Create(AuctionDto auction, CancellationToken cancellationToken)
            => await _auctionRepository.Create(auction, cancellationToken);

        public async Task<bool> Delete(int auctionId, CancellationToken cancellationToken)
        {
            try
            {
                await _auctionRepository.Delete(auctionId, cancellationToken);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
            => await _auctionRepository.GetAll(cancellationToken);

        public async Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken)
            => await _auctionRepository.GetById(auctionId, cancellationToken);

        public async Task<int> Update(AuctionDto auction, CancellationToken cancellationToken)
            => await _auctionRepository.Update(auction, cancellationToken);
  
    }
}
