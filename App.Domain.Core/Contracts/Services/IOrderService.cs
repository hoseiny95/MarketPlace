


using App.Domain.Core.Dtos.Orders;

namespace App.Domain.Core.Contracts.Services;

public interface IOrderService
{
    Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
    Task<List<OrderDto>> GetAllByCustmerId( int customerId,CancellationToken cancellationToken);
    Task<OrderDto> GetById(int orderId, CancellationToken cancellationToken);
    Task<int> Create(OrderDto order, CancellationToken cancellationToken);
    Task<int> Update(OrderDto order, CancellationToken cancellationToken);
    Task<bool> Delete(int orderId, CancellationToken cancellationToken);

}
