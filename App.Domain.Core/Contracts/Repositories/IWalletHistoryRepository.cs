

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories;

public interface IWalletHistoryRepository
{
    Task<List<WalletHistoryDto>> GetAll(CancellationToken cancellationToken);
    Task<WalletHistoryDto> GetById(int walletHistoryId, CancellationToken cancellationToken);
    Task Create(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task Update(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task Delete(int walletHistoryId, CancellationToken cancellationToken);
}
