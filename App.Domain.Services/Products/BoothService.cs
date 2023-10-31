using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Products;
using App.Domain.Core.Entities.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Products
{
    public class BoothService : IBoothService
    {
        private readonly IBoothRepository _boothRepository;

        public BoothService(IBoothRepository boothRepository)
        {
            _boothRepository = boothRepository;
        }

        public async Task<int> Create(BoothDto booth, CancellationToken cancellationToken)
            => await _boothRepository.Create(booth, cancellationToken);

        public async Task<bool> Delete(int boothId, CancellationToken cancellationToken)
        {
            try
            {
                await _boothRepository.Delete(boothId, cancellationToken);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
            => await _boothRepository.GetAll(cancellationToken);
        public async Task<BoothDto> GetById(int boothId, CancellationToken cancellationToken)
            => await _boothRepository.GetById(boothId, cancellationToken);

        public async Task<int> Update(BoothDto booth, CancellationToken cancellationToken)
            => await _boothRepository.Update(booth, cancellationToken);
    }
}
