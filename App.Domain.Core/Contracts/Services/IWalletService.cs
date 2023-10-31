

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services;

public interface IWalletService
{
    Task<List<WalletDto>> GetAll(CancellationToken cancellationToken);
    Task<WalletDto> GetById(int walletId, CancellationToken cancellationToken);
    Task Create(WalletDto walletDto, CancellationToken cancellationToken);
    Task Update(WalletDto walletDto, CancellationToken cancellationToken);
    Task Delete(int walletId, CancellationToken cancellationToken);


}
