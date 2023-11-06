using App.Domain.Core.Dtos.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices
{
    public interface IBoothAppService
    {
        Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
        Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken);
        Task Update(BoothDto boothDto, IFormFile photo, CancellationToken cancellationToken);
        Task<List<BoothDto>> GetAllDeleted(CancellationToken cancellationToken);
        Task<bool> Delete(int boothId, CancellationToken cancellationToken);
        Task Return(int boothId, CancellationToken cancellationToken);
    }
}
