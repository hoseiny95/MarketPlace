using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
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
    public async Task<int> Create(SellerDto seller, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<SellerDto>(seller);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
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


    public async Task<int> Update(SellerDto seller, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Seller>(seller);
        _context.Sellers.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
    public async Task<List<BoothProductDto>> GetBoothsByUserId(int userId, CancellationToken cancellationToken)
    {
        var booths = await _context.Sellers.Where(x => x.UserId == userId)
        .Include(c => c.Booth)
        .ThenInclude(c => c.BoothProducts)
        .ThenInclude(c => c.ProductImages).ThenInclude(c => c.Image).Include(c => c.Booth).ThenInclude(c => c.BoothProducts)
        .ThenInclude(c => c.Product).Include(c => c.MedalNavigation)
        .SelectMany(x => x.Booth.BoothProducts).ToListAsync(cancellationToken);


        var re = await (from p in _context.Sellers.Where(x => x.UserId == userId)
                  from c in _context.Booths
                  where p.BoothId == c.Id
                  select c
                  ).FirstOrDefaultAsync(cancellationToken);
        var seller = await _context.Sellers.Where(x => x.UserId == userId).Include(c => c.MedalNavigation).FirstOrDefaultAsync(cancellationToken);
        re.Seller = seller;
        booths.ForEach(x => x.Both = re);


        var boothDtos = _mapper.Map<List<BoothProductDto>>(booths);
        return boothDtos;
    }
    public async Task<int> GetBoothId(int userId, CancellationToken cancellationToken)
        => await _context.Sellers.Where(x => x.UserId == userId).Select(c => c.BoothId).FirstOrDefaultAsync(cancellationToken);

    public async Task<SellerDto> GetByBoothProductId(int boothProductId, CancellationToken cancellationToken)
    {
        var query = _context.Sellers.Include(c => c.Booth)
        .ThenInclude(c => c.BoothProducts).Where(x => x.Booth.BoothProducts.First().Id == boothProductId);
        return _mapper.Map<SellerDto>(await query.FirstOrDefaultAsync(cancellationToken));
    }
     
   public async Task<SellerDto> GetbyUserId(int userId, CancellationToken cancellationToken)
    {
       var seller = await  _context.Sellers.Include(c => c.User).ThenInclude(c => c.Wallet)
            .Include(c => c.Booth).ThenInclude(c => c.Image)
            .Where(x => x.UserId == userId).FirstOrDefaultAsync(cancellationToken);
        return _mapper.Map<SellerDto>(seller);
    }
}
