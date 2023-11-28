using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Generals;
using App.Domain.Core.Entities.Products;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Users;

public class CustomerRepository : ICustomerRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;
    public CustomerRepository(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Create(CustomerDto customer, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Customer>(customer);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }


    public async Task Delete(int CustomerId, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers.FindAsync(CustomerId, cancellationToken);
        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<CustomerDto>> GetAll(CancellationToken CancellationToken)
                  => _mapper.Map<List<CustomerDto>>(await _context.Customers.ToListAsync(CancellationToken));


    public async Task<CustomerDto> GetById(int customerId, CancellationToken CancellationToken)
                  => _mapper.Map<CustomerDto>(await _context.Customers.Include(c => c.Orders).ThenInclude(c => c.OrderLines)
                                .FirstOrDefaultAsync(x => x.Id == customerId, CancellationToken));

    public async Task<int> Update(CustomerDto customer, CancellationToken CancellationToken)
    {
        var entity = _mapper.Map<Customer>(customer);
        _context.Customers.Update(entity);
        await _context.SaveChangesAsync(CancellationToken);
        return entity.Id;
    }
    public async Task<CustomerDto> GetByUserId(int userId, CancellationToken CancellationToken)
    {
        var customer =  await _context.Customers.Include(c => c.User).ThenInclude(c=> c.Wallet).Include(c=> c.Orders)
            .Include(c=> c.Bids).Include(c => c.Image).Include(c => c.Orders).ThenInclude(c => c.OrderLines)
            .FirstOrDefaultAsync(x=> x.UserId == userId, CancellationToken);
        return _mapper.Map<CustomerDto>(customer);  
    }
    public async Task UpdateBaseInfo(CustomerDto customer, CancellationToken CancellationToken)
    {
        var custom = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id, CancellationToken);
        custom.Name = customer.Name; custom.Lastname = custom.Lastname; custom.ImageId = customer.ImageId;
        await _context.SaveChangesAsync(CancellationToken);
    }
}
