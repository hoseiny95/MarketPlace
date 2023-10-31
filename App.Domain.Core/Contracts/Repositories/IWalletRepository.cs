

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories;

public interface IWalletRepository
{
    Task<List<WalletDto>> GetAll(CancellationToken cancellationToken);
    Task<WalletDto> GetById(int walletId, CancellationToken cancellationToken);
    Task<int> Create(WalletDto walletDto, CancellationToken cancellationToken);
    Task<int> Update(WalletDto walletDto, CancellationToken cancellationToken);
    Task Delete(int walletId, CancellationToken cancellationToken);


}
