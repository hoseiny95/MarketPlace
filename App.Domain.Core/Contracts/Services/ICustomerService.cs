

using App.Domain.Core.Dtos.Users;

namespace App.Domain.Core.Contracts.Services; 

public interface ICustomerService
{

    Task<List<CustomerDto>> GetAll(CancellationToken CancellationToken);

    Task<CustomerDto> GetById(int customerId, CancellationToken CancellationToken);
    Task Update(CustomerDto customer, CancellationToken CancellationToken);
    Task Delete(int CustomerId, CancellationToken cancellationToken);

}
