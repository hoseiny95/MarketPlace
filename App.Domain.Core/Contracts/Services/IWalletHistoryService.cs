

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services;

public interface IWalletHistoryService
{
    Task<List<WalletHistoryDto>> GetAll(CancellationToken cancellationToken);
    Task<WalletHistoryDto> GetById(int walletHistoryId, CancellationToken cancellationToken);
    Task<int> Create(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task<int> Update(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task<bool> Delete(int walletHistoryId, CancellationToken cancellationToken);
    Task AddRange(List<WalletHistoryDto> walletHistories, CancellationToken cancellationToken);
    Task<List<WalletHistoryDto>> GetbySellrId(int sellerId, CancellationToken cancellationToken);
}
