


using App.Domain.Core.Dtos.Orders;

namespace App.Domain.Core.Contracts.Repositories;

public interface IOrderLineRipository
{
    Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
    Task<List<OrderDto>> GetAllByOrderId( int orderId,CancellationToken cancellationToken);
    Task<OrderDto> GetById(int orderId, CancellationToken cancellationToken);
    Task Create(OrderLineDto order, CancellationToken cancellationToken);
    Task Update(OrderLineDto order, CancellationToken cancellationToken);
    Task Delete(int orderLineId, CancellationToken cancellationToken);

}
