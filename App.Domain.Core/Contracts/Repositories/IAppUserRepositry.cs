

using App.Domain.Core.Dtos.Users;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Contracts.Repositories; 

public interface IAppUserRepositry
{
    Task<IdentityResult> Create(AppUserDto userDto, CancellationToken CancellationToken);
    Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken);
    Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken);
    Task<IdentityResult> Update(AppUserDto appuser, CancellationToken CancellationToken);
    Task Delete(int userId, CancellationToken cancellationToken);
    Task<SignInResult> Login(AppUserDto userDto, CancellationToken cancellationToken);
    Task<AppUserDto> GetByUserName(string userName , CancellationToken cancellationToken);

}
