

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services;

public interface IWalletHistoryService
{
    Task<List<WalletHistoryDto>> GetAll(CancellationToken cancellationToken);
    Task<WalletHistoryDto> GetById(int walletHistoryId, CancellationToken cancellationToken);
    Task Create(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task Update(WalletHistoryDto walletHistory, CancellationToken cancellationToken);
    Task Delete(int walletHistoryId, CancellationToken cancellationToken);
}
