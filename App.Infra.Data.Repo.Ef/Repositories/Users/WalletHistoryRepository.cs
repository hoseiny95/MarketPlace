﻿using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Users
{
    public class WalletHistoryRepository : IWalletHistoryRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public WalletHistoryRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(WalletHistoryDto walletHistory, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WalletHistoryDto>(walletHistory);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int walletHistoryId, CancellationToken cancellationToken)
        {
            var entity = await _context.WalletHistories.FindAsync(walletHistoryId, cancellationToken);
            _context.WalletHistories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<WalletHistoryDto>> GetAll(CancellationToken cancellationToken)
                       => _mapper.Map<List<WalletHistoryDto>>(await _context.WalletHistories.ToListAsync(cancellationToken));


        public async Task<WalletHistoryDto> GetById(int walletHistoryId, CancellationToken cancellationToken)
                        => _mapper.Map<WalletHistoryDto>(await _context.WalletHistories
                     .FirstOrDefaultAsync(x => x.Id == walletHistoryId, cancellationToken));

        public async Task Update(WalletHistoryDto walletHistory, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WalletHistory>(walletHistory);
            _context.WalletHistories.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}