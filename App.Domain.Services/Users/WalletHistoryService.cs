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

public class WalletHistoryService : IWalletHistoryService
{
    private readonly IWalletHistoryRepository _historyRepository;

    public WalletHistoryService(IWalletHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public async Task AddRange(List<WalletHistoryDto> walletHistories, CancellationToken cancellationToken)
        => await _historyRepository.AddRange(walletHistories, cancellationToken);

    public async Task<int> Create(WalletHistoryDto walletHistory, CancellationToken cancellationToken)
        => await _historyRepository.Create(walletHistory, cancellationToken);

    public async Task<bool> Delete(int walletHistoryId, CancellationToken cancellationToken)
    {
        try
        {
            await _historyRepository.Delete(walletHistoryId,cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<WalletHistoryDto>> GetAll(CancellationToken cancellationToken)
        => await _historyRepository.GetAll(cancellationToken);

    public async Task<WalletHistoryDto> GetById(int walletHistoryId, CancellationToken cancellationToken)
        => await _historyRepository.GetById(walletHistoryId, cancellationToken);

    public async Task<List<WalletHistoryDto>> GetbySellrId(int sellerId, CancellationToken cancellationToken)
        => await _historyRepository.GetbySellrId(sellerId, cancellationToken);

    public async Task<int> Update(WalletHistoryDto walletHistory, CancellationToken cancellationToken)
        => await _historyRepository.Update(walletHistory, cancellationToken);
}
