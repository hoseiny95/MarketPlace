using App.Domain.Core.Contracts.Repositories;
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
    public class WalletRepository : IWalletRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public WalletRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(WalletDto walletDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Wallet>(walletDto);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task Delete(int walletId, CancellationToken cancellationToken)
        {
            var entity = await _context.Wallets.FindAsync(walletId, cancellationToken);
            _context.Wallets.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<WalletDto>> GetAll(CancellationToken cancellationToken)
                      => _mapper.Map<List<WalletDto>>(await _context.Wallets.ToListAsync(cancellationToken));


        public async Task<WalletDto> GetById(int walletId, CancellationToken cancellationToken)
                      => _mapper.Map<WalletDto>(await _context.Wallets
                     .FirstOrDefaultAsync(x => x.Id == walletId, cancellationToken));

        public async Task<int> Update(WalletDto walletDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Wallet>(walletDto);
            _context.Wallets.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;        }
    }
}
