using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

internal class WalletHistoryService : IWalletHistoryService
{
    public Task Create(WalletHistoryDto walletHistory, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int walletHistoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<WalletHistoryDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<WalletHistoryDto> GetById(int walletHistoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(WalletHistoryDto walletHistory, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
