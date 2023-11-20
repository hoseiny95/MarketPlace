using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface IOrderAppService
{
    Task UpdateSellersWallet(int orderId, CancellationToken cancellationToken);
}
