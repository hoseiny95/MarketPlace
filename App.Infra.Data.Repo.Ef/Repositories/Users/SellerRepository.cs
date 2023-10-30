using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Users;

public class SellerRepository : ISellerRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;

    public SellerRepository(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Create(SellerDto seller, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<SellerDto>(seller);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(int sellerId, CancellationToken cancellationToken)
    {
        var entity = await _context.Sellers.FindAsync(sellerId, cancellationToken);
        _context.Sellers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<SellerDto>> GetAll(CancellationToken cancellationToken)
                        => _mapper.Map<List<SellerDto>>(await _context.Sellers.ToListAsync(cancellationToken));


    public async Task<SellerDto> GetById(int sellerId, CancellationToken cancellationToken)
                 => _mapper.Map<SellerDto>(await _context.Sellers
                     .FirstOrDefaultAsync(x => x.Id == sellerId, cancellationToken));
    

    public async Task Update(SellerDto seller, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Seller>(seller);
        _context.Sellers.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
