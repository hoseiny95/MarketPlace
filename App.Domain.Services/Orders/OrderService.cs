using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Orders;
using App.Domain.Core.Entities.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> Create(OrderDto order, CancellationToken cancellationToken)
        => await _orderRepository.Create(order, cancellationToken);

    public async Task<bool> Delete(int orderLineId, CancellationToken cancellationToken)
    {
        try
        {
            await _orderRepository.Delete(orderLineId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        => await _orderRepository.GetAll(cancellationToken);

    public Task<List<OrderDto>> GetAllByCustmerId(int customerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderDto> GetById(int orderId, CancellationToken cancellationToken)
        => await _orderRepository.GetById(orderId, cancellationToken);

    public async Task<int> Update(OrderDto order, CancellationToken cancellationToken)
        => await _orderRepository.Update(order, cancellationToken);
}
