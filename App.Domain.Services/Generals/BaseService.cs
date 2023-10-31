using App.Domain.Core.Contracts.Repositories;
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
        private readonly IBaseRepository _baseRepository;

        public BaseService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<List<CityDto>> GetAllCitis(CancellationToken CancellationToken)
            => await _baseRepository.GetAllCitis(CancellationToken);
        

        public async Task<List<ProvinceDto>> GetAllProvinces(CancellationToken CancellationToken)
            => await _baseRepository.GetAllProvinces(CancellationToken);



        public async Task<CityDto> GetCityById(int cityId, CancellationToken cancellationToken)
            => await _baseRepository.GetCityById(cityId ,cancellationToken);



        public async Task<ProvinceDto> GetProvinceById(int provinceId, CancellationToken cancellationToken)
             => await _baseRepository.GetProvinceById(provinceId , cancellationToken);

    }
}
