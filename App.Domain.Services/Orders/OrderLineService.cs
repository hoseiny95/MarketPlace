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

public class OrderLineService : IOrderLineService
{
    private readonly IOrderLineRepository orderLineRepository;

    public OrderLineService(IOrderLineRepository orderLineRepository)
    {
        this.orderLineRepository = orderLineRepository;
    }

    public async Task<int> Create(OrderLineDto order, CancellationToken cancellationToken)
        => await orderLineRepository.Create(order, cancellationToken);

    public async Task<bool> Delete(int orderLineId, CancellationToken cancellationToken)
    {
        try
        {
            await orderLineRepository.Delete(orderLineId, cancellationToken);
            return true;
        }
        catch { return false; }
    }

    public async Task<List<OrderLineDto>> GetAll(CancellationToken cancellationToken)
        => await orderLineRepository.GetAll(cancellationToken);

    public async Task<List<OrderLineDto>> GetAllByOrderId(int orderId, CancellationToken cancellationToken)
        => await orderLineRepository.GetAllByOrderId(orderId, cancellationToken);

    public async Task<OrderLineDto> GetById(int orderId, CancellationToken cancellationToken)
        => await orderLineRepository.GetById(orderId, cancellationToken);

    public async Task<int> Update(OrderLineDto order, CancellationToken cancellationToken)
        => await orderLineRepository.Update(order, cancellationToken);  
}
