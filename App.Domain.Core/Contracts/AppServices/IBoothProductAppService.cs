﻿using App.Domain.Core.Dtos.Admin;
using App.Domain.Core.Dtos.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices
{
    public interface IBoothProductAppService
    {
        Task UpdateAdminProduct(ProductAdminDto adminProduct,IFormFile photo,CancellationToken cancellationToken);
        Task<List<ProductAdminDto>> GetAdminProductsNotConfirm(CancellationToken cancellationToken);
        Task ConfirmProduct(int id,string confirm,string refuse, CancellationToken cancellationToken);
        Task<bool> Delete(int boothProductId, CancellationToken cancellationToken);
        Task Create(BoothProductDto boothProductDto, IFormFile photo, int imageId, CancellationToken cancellationToken);

    }
}
