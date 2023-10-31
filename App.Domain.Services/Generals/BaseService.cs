using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Generals
{
    public class BaseService : IBaseService
    {
        public Task<List<CityDto>> GetAllCitis(CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProvinceDto>> GetAllProvinces(CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CityDto> GetCityById(int cityId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProvinceDto> GetProvinceById(int provinceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
