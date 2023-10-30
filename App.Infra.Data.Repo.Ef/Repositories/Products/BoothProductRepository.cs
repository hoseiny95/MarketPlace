using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Auctions;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Products;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Products
{
    public class BoothProductRepository : IBoothProductRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;
        public BoothProductRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(BoothProductDto boothProduct, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoothProduct>(boothProduct);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int boothProductId, CancellationToken cancellationToken)
        {
            var entity = await _context.BoothProducts.FindAsync(boothProductId, cancellationToken);
            _context.BoothProducts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<BoothProductDto>> GetAll(CancellationToken cancellationToken)
                    => _mapper.Map<List<BoothProductDto>>(await _context.BoothProducts.ToListAsync(cancellationToken));


        public async Task<BoothProductDto> GetById(int boothProductId, CancellationToken cancellationToken)
                    => _mapper.Map<BoothProductDto>(await _context.BoothProducts.FirstOrDefaultAsync(x => x.Id == boothProductId, cancellationToken));


        public async Task Update(BoothProductDto boothProduct, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoothProduct>(boothProduct);
            _context.BoothProducts.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
