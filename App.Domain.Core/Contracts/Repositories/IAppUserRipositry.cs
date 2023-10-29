

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories; 

public interface IAppUserRipositry
{

    Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken);
    Task<AppUserDto> GetById(int userId, CancellationToken CancellationToken);
    Task Update(AppUserDto appuser, CancellationToken CancellationToken);
    Task Delete(int userId, CancellationToken cancellationToken);

}
