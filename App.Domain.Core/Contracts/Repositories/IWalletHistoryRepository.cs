

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories;

public interface IWalletHistoryRepository
{
    Task<List<WalletHistoryDto>> GetAll(CancellationToken cancellationToken);
    Task<WalletHistoryDto> GetById(int walletHistoryId, CancellationToken cancellationToken);
    Task<int> Create(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task<int> Update(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task Delete(int walletHistoryId, CancellationToken cancellationToken);
    Task AddRange(List<WalletHistoryDto> walletHistories, CancellationToken cancellationToken);
    Task<List<WalletHistoryDto>> GetbySellrId(int sellerId, CancellationToken cancellationToken);
}
