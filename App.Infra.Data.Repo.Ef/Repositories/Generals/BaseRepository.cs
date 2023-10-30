using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dtos.Generals;
using App.Infra.Db.Sql.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infra.Data.Repo.Ef.Repositories.Generals
{
    public class BaseRepository : IBaseRepository
    {
        private readonly MarketPlaceContext _context;
        private readonly IMapper _mapper;

        public BaseRepository(MarketPlaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CityDto>> GetAllCitis(CancellationToken CancellationToken)
                        => _mapper.Map<List<CityDto>>(await _context.Cities.ToListAsync(CancellationToken));


        public async Task<List<ProvinceDto>> GetAllProvinces(CancellationToken CancellationToken)
                      => _mapper.Map<List<ProvinceDto>>(await _context.Provinces.ToListAsync(CancellationToken));


        public async Task<CityDto> GetCityById(int cityId, CancellationToken cancellationToken)
                     => _mapper.Map<CityDto>(await _context.Cities
                         .FirstOrDefaultAsync(x => x.Id == cityId, cancellationToken));

        public async Task<ProvinceDto> GetProvinceById(int provinceId, CancellationToken cancellationToken)
                     => _mapper.Map<ProvinceDto>(await _context.Provinces
                         .FirstOrDefaultAsync(x => x.Id == provinceId, cancellationToken));
    }
}
