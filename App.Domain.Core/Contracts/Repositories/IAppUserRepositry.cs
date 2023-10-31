

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories; 

public interface IAppUserRepositry
{

    Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken);
    Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken);
    Task<int> Update(AppUserDto appuser, CancellationToken CancellationToken);
    Task Delete(int userId, CancellationToken cancellationToken);

}
