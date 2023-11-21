

using App.Domain.Core.Dtos.Users;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Contracts.Services; 

public interface IAppUserService
{
    Task<IdentityResult> Create(AppUserDto user, CancellationToken CancellationToken);
    Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken);
    Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken);
    Task<IdentityResult> Update(AppUserDto appuser, CancellationToken CancellationToken);
    Task<bool> Delete(int userId, CancellationToken cancellationToken);
    public Task<SignInResult> Login(AppUserDto userDto, CancellationToken cancellationToken);
    Task<AppUserDto> GetByUserName(string userName, CancellationToken cancellationToken);
}
