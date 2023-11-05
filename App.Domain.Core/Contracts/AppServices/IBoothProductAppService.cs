using App.Domain.Core.Dtos.Admin;
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

    }
}
