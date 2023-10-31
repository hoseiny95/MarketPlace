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

public class OrderService : IOrderLineService
{
    private readonly IOrderLineRepository _orderLineRepository;

    public OrderService(IOrderLineRepository orderLineRepository)
    {
        _orderLineRepository = orderLineRepository;
    }

    public async Task<int> Create(OrderLineDto order, CancellationToken cancellationToken)
        => await _orderLineRepository.Create(order, cancellationToken);

    public async Task<bool> Delete(int orderLineId, CancellationToken cancellationToken)
    {
        try
        {
            await _orderLineRepository.Delete(orderLineId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<OrderLineDto>> GetAll(CancellationToken cancellationToken)
        => await _orderLineRepository.GetAll(cancellationToken);

    public async Task<List<OrderLineDto>> GetAllByOrderId(int orderId, CancellationToken cancellationToken)
        => await _orderLineRepository.GetAllByOrderId(orderId, cancellationToken);  

    public async Task<OrderLineDto> GetById(int orderId, CancellationToken cancellationToken)
        => await _orderLineRepository.GetById(orderId, cancellationToken);

    public async Task<int> Update(OrderLineDto order, CancellationToken cancellationToken)
        => await _orderLineRepository.Update(order, cancellationToken);
}
