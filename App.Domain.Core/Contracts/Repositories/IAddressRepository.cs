

using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories;

public interface IAddressRepository
{
    Task<List<AddressDto>> GetAll(CancellationToken CancellationToken);
    Task<AddressDto> GetById(int AddressId, CancellationToken cancellationToken);
    Task<int> Update(AddressDto Address, CancellationToken cancellationToken);
    Task<int> Create(AddressDto Address, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);

}
