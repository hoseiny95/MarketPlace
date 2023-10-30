


using App.Domain.Core.Dtos.Orders;

namespace App.Domain.Core.Contracts.Repositories;

public interface IOrderLineRepository
{
    Task<List<OrderLineDto>> GetAll(CancellationToken cancellationToken);
    Task<List<OrderLineDto>> GetAllByOrderId( int orderId,CancellationToken cancellationToken);
    Task<OrderLineDto> GetById(int orderId, CancellationToken cancellationToken);
    Task Create(OrderLineDto order, CancellationToken cancellationToken);
    Task Update(OrderLineDto order, CancellationToken cancellationToken);
    Task Delete(int orderLineId, CancellationToken cancellationToken);

}
