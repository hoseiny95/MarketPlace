using App.Domain.Core.Dtos.Generals;
using App.Domain.Core.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repositories
{
    public interface IBaseRepository
    {
        Task<List<CityDto>> GetAllCitis(CancellationToken CancellationToken);
        Task<CityDto> GetCityById(int cityId, CancellationToken cancellationToken);
        Task<List<ProvinceDto>> GetAllProvinces(CancellationToken CancellationToken);
        Task<ProvinceDto> GetProvinceById(int provinceId, CancellationToken cancellationToken);
    }
}
