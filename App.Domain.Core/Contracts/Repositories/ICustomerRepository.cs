

using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Repositories; 

public interface ICustomerRepository
{
    Task<int> Create(CustomerDto customer, CancellationToken cancellationToken);
    Task<List<CustomerDto>> GetAll(CancellationToken CancellationToken);
    Task<CustomerDto> GetById(int customerId, CancellationToken CancellationToken);
    Task<int> Update(CustomerDto customer, CancellationToken CancellationToken);
    Task Delete(int CustomerId, CancellationToken cancellationToken);
    Task<CustomerDto> GetByUserId(int userId, CancellationToken CancellationToken);
}
