using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Users;

public class CustomerService : ICustomerService
{
    public Task Delete(int CustomerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CustomerDto>> GetAll(CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDto> GetById(int customerId, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CustomerDto customer, CancellationToken CancellationToken)
    {
        throw new NotImplementedException();
    }
}
