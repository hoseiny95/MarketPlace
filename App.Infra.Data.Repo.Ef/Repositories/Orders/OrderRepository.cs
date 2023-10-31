using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Orders;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Auctions;
using App.Domain.Core.Entities.Orders;
using App.Domain.Core.Entities.Users;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;
    public OrderRepository(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<int> Create(OrderDto order, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<OrderDto>(order);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task Delete(int orderId, CancellationToken cancellationToken)
    {
        var entity = await _context.Orders.FindAsync(orderId, cancellationToken);
        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
                      => _mapper.Map<List<OrderDto>>(await _context.Orders.ToListAsync(cancellationToken));


    public async Task<List<OrderDto>> GetAllByCustmerId(int customerId, CancellationToken cancellationToken)
                          => _mapper.Map<List<OrderDto>>(await _context.Orders.Where(x => x.CustomerId == customerId)
                              .ToListAsync(cancellationToken));


    public async Task<OrderDto> GetById(int orderId, CancellationToken cancellationToken)
                  => _mapper.Map<OrderDto>(await _context.Orders
                                .FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken));

    public async Task<int> Update(OrderDto order, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Order>(order);
        _context.Orders.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;   
    }
}
