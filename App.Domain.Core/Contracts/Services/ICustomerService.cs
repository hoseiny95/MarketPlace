

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services; 

public interface ICustomerService
{

    Task<List<CustomerDto>> GetAll(CancellationToken CancellationToken);
    Task<CustomerDto> GetById(int customerId, CancellationToken CancellationToken);
    Task<int> Update(CustomerDto customer, CancellationToken CancellationToken);
    Task<int> Create(CustomerDto customer, CancellationToken CancellationToken);
    Task<bool> Delete(int CustomerId, CancellationToken cancellationToken);
    Task<CustomerDto> GetByUserId(int userId, CancellationToken CancellationToken);
}
