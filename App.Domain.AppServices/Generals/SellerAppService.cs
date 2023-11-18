using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Generals
{
    public class SellerAppService : ISellerAppService
    {
        private readonly ISellerService _sellerService;
        private readonly IAppUserService _appUserService;

        public SellerAppService(ISellerService sellerService, IAppUserService appUserService )
        {
            _sellerService = sellerService;
            _appUserService = appUserService;
        }
        public async Task<List<BoothProductDto>> GetSellerBooths(string userName, CancellationToken cancellationToken)
        {
            var user = await _appUserService.GetByUserName(userName, cancellationToken);
            return await _sellerService.GetBoothsByUserId(user.Id, cancellationToken);
        }
        public async Task<int> GetSellerBoothId(string userName, CancellationToken cancellationToken)
        {
            var user = await _appUserService.GetByUserName(userName, cancellationToken);
            var mee = await _sellerService.GetBoothId(user.Id, cancellationToken);
            return mee;
        }
    }
}
