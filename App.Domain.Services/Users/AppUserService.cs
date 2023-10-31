using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

public class AppUserService : IAppUserService
{
    public Task Delete(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(AppUserDto appuser, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<bool> IAppUserService.Delete(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<int> IAppUserService.Update(AppUserDto appuser, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }
}
