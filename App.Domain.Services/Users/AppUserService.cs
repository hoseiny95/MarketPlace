using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

public class AppUserService : IAppUserService
{
    private readonly IAppUserRepositry _appRepository;

    public AppUserService(IAppUserRepositry appRepository)
    {
        _appRepository = appRepository;
    }

    public async Task<IdentityResult> Create(AppUserDto user, CancellationToken CancellationToken)
        => await _appRepository.Create(user, CancellationToken);

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

    public async Task<SignInResult> Login(AppUserDto userDto, CancellationToken cancellationToken)
        => await _appRepository.Login(userDto, cancellationToken);
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
