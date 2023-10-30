using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Entities.Auctions;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Auctions;

public class BidRepository : IBidRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;

    public BidRepository(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Create(BidDto bid, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Bid>(bid);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(int bidId, CancellationToken cancellationToken)
    {
        var entity = await _context.Bids.FindAsync(bidId, cancellationToken);
        _context.Bids.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
                => _mapper.Map<List<BidDto>>(await _context.Bids.ToListAsync(cancellationToken));


    public async Task<List<BidDto>> GetAllByAuctionId(int AuctionId, CancellationToken cancellationToken)
                 => _mapper.Map<List<BidDto>>(await _context.Bids.Where(x=> x.AuctionId== AuctionId).ToListAsync(cancellationToken));


    public async Task<BidDto> GetById(int bidId, CancellationToken cancellationToken)
                => _mapper.Map<BidDto>(await _context.Bids.FirstOrDefaultAsync(x => x.Id == bidId, cancellationToken));

    public async Task<List<BidDto>> GetUserBids(int userID, CancellationToken cancellationToken)
                 => _mapper.Map<List<BidDto>>(await _context.Bids.Where(x => x.CustomerId == userID).ToListAsync(cancellationToken));

}
