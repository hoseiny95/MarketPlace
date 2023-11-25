using App.Domain.Core.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface IOrderAppService
{
    Task UpdateSellersWallet(int orderId, CancellationToken cancellationToken);
    Task<int> ByeProduct(int BoothProductId, string username, CancellationToken cancellationToken);
    Task<OrderDto> GetbyId(int orderId, CancellationToken cancellationToken);
}
