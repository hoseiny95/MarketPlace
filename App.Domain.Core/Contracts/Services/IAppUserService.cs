

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services; 

public interface IAppUserService
{

    Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken);
    Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken);
    Task<int> Update(AppUserDto appuser, CancellationToken CancellationToken);
    Task<bool> Delete(int userId, CancellationToken cancellationToken);

}
