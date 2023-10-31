


using App.Domain.Core.Dtos.Orders;

namespace App.Domain.Core.Contracts.Repositories;

public interface IOrderRepository
{
    Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
    Task<List<OrderDto>> GetAllByCustmerId( int customerId,CancellationToken cancellationToken);
    Task<OrderDto> GetById(int orderId, CancellationToken cancellationToken);
    Task<int> Create(OrderDto order, CancellationToken cancellationToken);
    Task<int> Update(OrderDto order, CancellationToken cancellationToken);
    Task Delete(int orderId, CancellationToken cancellationToken);

}
