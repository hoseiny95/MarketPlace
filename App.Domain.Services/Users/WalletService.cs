using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

public class WalletService : IWalletService
{
    public Task Create(WalletDto walletDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int walletId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<WalletDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<WalletDto> GetById(int walletId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(WalletDto walletDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
