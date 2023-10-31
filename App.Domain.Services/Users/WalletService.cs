using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<int> Create(WalletDto walletDto, CancellationToken cancellationToken)
        => await _walletRepository.Create(walletDto, cancellationToken);

    public async Task<bool> Delete(int walletId, CancellationToken cancellationToken)
    {
        try
        {
            await _walletRepository.Delete(walletId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<WalletDto>> GetAll(CancellationToken cancellationToken)
        => await _walletRepository.GetAll(cancellationToken);

    public async Task<WalletDto> GetById(int walletId, CancellationToken cancellationToken)
        => await _walletRepository.GetById(walletId, cancellationToken);

    public async Task<int> Update(WalletDto walletDto, CancellationToken cancellationToken)
        => await _walletRepository.Update(walletDto, cancellationToken);
}
