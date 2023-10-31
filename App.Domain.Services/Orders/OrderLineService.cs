using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Orders;

public class OrderLineService : IOrderLineService
{
    public Task Create(OrderLineDto order, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int orderLineId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderLineDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderLineDto>> GetAllByOrderId(int orderId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<OrderLineDto> GetById(int orderId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(OrderLineDto order, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
