using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices
{
    public interface ISellerAppService
    {
        Task<List<BoothProductDto>> GetSellerBooths(string userName, CancellationToken cancellationToken);
        Task<int> GetSellerBoothId(string userName, CancellationToken cancellationToken);
    }
}
