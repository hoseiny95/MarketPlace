


using App.Domain.Core.Dtos.Orders;

namespace App.Domain.Core.Contracts.Services;

public interface IOrderLineService
{
    Task<List<OrderLineDto>> GetAll(CancellationToken cancellationToken);
    Task<List<OrderLineDto>> GetAllByOrderId( int orderId,CancellationToken cancellationToken);
    Task<OrderLineDto> GetById(int orderId, CancellationToken cancellationToken);
    Task<int> Create(OrderLineDto order, CancellationToken cancellationToken);
    Task<int> Update(OrderLineDto order, CancellationToken cancellationToken);
    Task<bool> Delete(int orderLineId, CancellationToken cancellationToken);

}
