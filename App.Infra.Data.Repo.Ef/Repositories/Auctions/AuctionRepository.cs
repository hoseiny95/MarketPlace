﻿using App.Domain.Core.Contracts.Repositories;
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

public class AuctionRepository : IAuctionRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;

    public AuctionRepository(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<int> Create(AuctionDto auction, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Auction>(auction);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task Delete(int auctionId, CancellationToken cancellationToken)
    {
        var entity = await _context.Auctions.FindAsync(auctionId, cancellationToken);
        _context.Auctions.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

    }

    public async Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
            => _mapper.Map<List<AuctionDto>>(await _context.Auctions.ToListAsync(cancellationToken));


    public async Task<AuctionDto> GetById(int auctionId, CancellationToken cancellationToken)
                    => _mapper.Map<AuctionDto>(await _context.Auctions.Include(c => c.Bids).FirstOrDefaultAsync(x => x.Id == auctionId, cancellationToken));



    public async Task<int> Update(AuctionDto auction, CancellationToken cancellationToken)
    {
        var entity = await _context.Auctions.FirstOrDefaultAsync(x => x.Id == auction.Id, cancellationToken);
        entity.LastPrice = auction.LastPrice;
        entity.IsSold = auction.IsSold;
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
