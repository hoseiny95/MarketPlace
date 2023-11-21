using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Dtos.Users;
using App.Domain.Core.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices
{
    public interface ISellerAppService
    {
        Task<List<BoothProductDto>> GetSellerBooths(string userName, CancellationToken cancellationToken);
        Task<int> GetSellerBoothId(string userName, CancellationToken cancellationToken);
        Task<SellerDto> GetSellerByUserName(string userName, CancellationToken cancellationToken);
        Task<Tuple<IdentityResult, bool>> EditProfile(SellerDto seller, IFormFile photo, CancellationToken cancellationToken);
    }
}
