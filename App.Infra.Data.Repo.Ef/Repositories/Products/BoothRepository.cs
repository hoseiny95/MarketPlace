using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Products;
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
    public class BoothRepository : IBoothRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;
        public BoothRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(BoothDto booth, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(booth);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
        public async Task Delete(int boothId, CancellationToken cancellationToken)
        {
            var entity = await _context.Booths.FindAsync(boothId, cancellationToken);
            _context.Booths.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
                            => _mapper.Map<List<BoothDto>>(await _context.Booths.ToListAsync(cancellationToken));


        public async Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken)
        {
            var res = await _context.Booths.ToListAsync(cancellationToken);
               var res22 = res.FirstOrDefault(x => x.Id == boothId);
            return _mapper.Map<BoothDto>(res22);

        }


        public async Task<int> Update(BoothDto booth, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(booth);
            //var me2 = await GetById(booth.Id, cancellationToken);
            _context.ChangeTracker.Clear();
            _context.Booths.Update(entity);
            //var me = await GetById(booth.Id, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
