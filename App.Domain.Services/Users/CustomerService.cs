using App.Domain.Core.Contracts.Repositories;
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
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> Create(CustomerDto customer, CancellationToken CancellationToken)
        => await _customerRepository.Create(customer,CancellationToken);

    public async Task<bool> Delete(int CustomerId, CancellationToken cancellationToken)
    {
        try
        {
            await _customerRepository.Delete(CustomerId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<CustomerDto>> GetAll(CancellationToken CancellationToken)
        => await _customerRepository.GetAll(CancellationToken);

    public async Task<CustomerDto> GetById(int customerId, CancellationToken CancellationToken)
        => await _customerRepository.GetById(customerId, CancellationToken);

    public async Task<CustomerDto> GetByUserId(int userId, CancellationToken CancellationToken)
        => await _customerRepository.GetByUserId(userId, CancellationToken);

    public async Task<int> Update(CustomerDto customer, CancellationToken CancellationToken)
        => await _customerRepository.Update(customer, CancellationToken);

    public async Task UpdateBaseInfo(CustomerDto customer, CancellationToken CancellationToken)
        => await _customerRepository.UpdateBaseInfo(customer, CancellationToken);

    public Task UpdateCustomerBaseInfo(CustomerDto customer, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
