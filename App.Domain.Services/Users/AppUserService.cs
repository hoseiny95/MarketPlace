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
    {
        if (user.Role == null)
        {
            if (user.IsSeller == true)
                user.Role = "Seller";
            else
                user.Role = "Customer";
        }
       
       return await _appRepository.Create(user, CancellationToken);
    }

    public async Task<bool> Delete(int userId, CancellationToken cancellationToken)
    {
        try
        {
        await _appRepository.Delete(userId, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken)
        => await _appRepository.GetAll(CancellationToken);

    public async Task<AppUserDto> GetByEmail(string email, CancellationToken cancellationToken)
        => await _appRepository.GetByEmail(email, cancellationToken);   

    public async Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken)
        => await _appRepository.GetById(userId, CancellationToken);

    public async Task<AppUserDto> GetByUserName(string userName, CancellationToken cancellationToken)
        => await _appRepository.GetByUserName(userName, cancellationToken);

    public async Task<SignInResult> Login(AppUserDto userDto, CancellationToken cancellationToken)
        => await _appRepository.Login(userDto, cancellationToken);
    public async Task<IdentityResult> Update(AppUserDto appuser, CancellationToken CancellationToken)
        => await _appRepository.Update(appuser, CancellationToken);

   
}
