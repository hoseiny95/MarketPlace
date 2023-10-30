﻿using App.Domain.Core.Contracts.Repositories;
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
        public async Task Create(BoothDto booth, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(booth);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
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
                            => _mapper.Map<BoothDto>(await _context.Booths.FirstOrDefaultAsync(x => x.Id == boothId, cancellationToken));


        public async Task Update(BoothDto booth, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(booth);
            _context.Booths.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}