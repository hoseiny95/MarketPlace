using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Admin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Products
{
    public class BoothProductAppService : IBoothProductAppService
    {
        private IBoothProductService _boothProductService;

        public BoothProductAppService(IBoothProductService boothProductService)
        {
            _boothProductService = boothProductService;
        }

        public Task UpdateAdminProduct(ProductAdminDto adminProduct, IFormFile photo, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
